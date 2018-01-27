using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using GlobalGameJam2018Networking.Protocol.MessageToAlchemy;
using GlobalGameJam2018Networking.Protocol.MessageToPipes;

namespace GlobalGameJam2018Networking
{
    public class PipesNetwork : NetworkBase
    {
        public string Username { get; private set; }

        public override event Action<string> ReceivedMessage;

        /// <summary>Called when the connection to the other game was established. The username of the other player is given as event argument.</summary>
        public event Action<string> AlchemistConnected;

        /// <summary>Called if the connection to the other game was lost.</summary>
        public event Action AlchemistDisconnected;

        /// <summary>Called when a moneymaker product was received from the alchemist.</summary>
        public event Action<MoneyMaker, Pipe> ReceivedMoneyMaker;

        /// <summary>Called when the alchemist finished the level. The bool argument is true for success and false for failure.</summary>
        public event Action<bool> GameOver;

        private object monitor = new object();

        private TcpListener tcpListener;
        private TcpClient tcpClient;

        /// <param name="invoke">Action that invokes given actions on the main unity thread.</param>
        public PipesNetwork(Action<Action> invoke) : base(invoke) { }

        public void Start(string username, int port = DefaultPort)
        {
            lock (monitor)
            {
                if (tcpListener != null) { throw new InvalidOperationException($"Can't start {nameof(PipesNetwork)} multiple times"); }
                Username = username;
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();
                tcpListener.BeginAcceptTcpClient(AcceptClient, null);
            }
        }

        public void Stop()
        {
            lock (monitor)
            {
                try
                {
                    if (tcpClient?.Connected ?? false) { tcpClient?.GetStream()?.Close(); }
                    tcpListener?.Stop();
                }
                catch (Exception) { } // <- Ugly game jam code
            }

        }

        private void AcceptClient(IAsyncResult result)
        {
            new Thread(() =>
            {
                try
                {
                    NetworkStream stream;
                    lock (monitor)
                    {
                        tcpClient = tcpListener.EndAcceptTcpClient(result);
                        stream = tcpClient.GetStream();
                        SendMessage(new WelcomeAlchemistIAm(Username));
                    }
                    Handle(ReadMessages<IToPipes>(stream));
                }
                catch (Exception) { } // <- Ugly game jam code

                lock (monitor) { tcpClient = null; }
                invoke(() => AlchemistDisconnected?.Invoke());

                // Accept a new client after this one quits
                tcpListener.BeginAcceptTcpClient(AcceptClient, null);
            }).Start();
        }

        /// <summary>Handles incomming messages. This method is running own the thread created in <see cref="AcceptClient(IAsyncResult)"/>.</summary>
        /// <param name="messages">Incomming messages.</param>
        private void Handle(IEnumerable<IToPipes> messages)
        {
            foreach (var message in messages)
            {
                switch (message)
                {
                    case ChatMessageToPipes chatMessage:
                        invoke(() => ReceivedMessage?.Invoke(chatMessage.Message));
                        break;
                    case GameOver gameOver:
                        invoke(() => GameOver?.Invoke(gameOver.Success));
                        break;
                    case SendMoneyMaker moneyMaker:
                        invoke(() => ReceivedMoneyMaker?.Invoke(moneyMaker.MoneyMaker, moneyMaker.Pipe));
                        break;
                    case WelcomePlumberIAm welcome:
                        invoke(() => AlchemistConnected?.Invoke(welcome.Username));
                        break;
                }
            }
        }

        private void SendMessage(IToAlchemy message)
        {
            lock (monitor)
            {
                if(tcpClient != null && tcpClient.Connected) { SendMessage(tcpClient.GetStream(), message); }
            }
        }

        public override void SendMessage(string message) => SendMessage(new ChatMessageToAlchemy(message));
        public void StartLevel(LevelConfig config) => SendMessage(new StartLevel(config));
        public void SendIngredient(Ingredient ingredient, Pipe pipe) => SendMessage(new SendIngredient(ingredient, pipe));
    }
}
