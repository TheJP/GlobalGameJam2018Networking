using GlobalGameJam2018Networking.Protocol.MessageToAlchemy;
using GlobalGameJam2018Networking.Protocol.MessageToPipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace GlobalGameJam2018Networking
{
    public class AlchemyNetwork : NetworkBase
    {
        public string Username { get; private set; }

        public override event Action<string> ReceivedMessage;

        public event Action<string> Connected;

        /// <summary>Called when the level is started by the plumber.</summary>
        public event Action<LevelConfig> LevelStarted;

        /// <summary>Called when an ingredient was recieved from the plumber.</summary>
        public event Action<Ingredient, Pipe> ReceivedIngredient;

        /// <summary>Called when the connection to the plumber was lost.</summary>
        public event Action ServerStopped;

        private object monitor = new object();

        private TcpClient tcpClient;

        /// <param name="invoke">Action that invokes given actions on the main unity thread.</param>
        public AlchemyNetwork(Action<Action> invoke) : base(invoke) { }

        public void Connect(string username, string hostname, int port = DefaultPort)
        {
            lock (monitor)
            {
                if (tcpClient != null) { throw new InvalidOperationException($"Can't connect {nameof(AlchemyNetwork)} multiple times"); }
                Username = username;
                tcpClient = new TcpClient();
                tcpClient.BeginConnect(hostname, port, ServerConnected, null);
            }
        }

        public void Disconnect()
        {
            lock (monitor)
            {
                if (tcpClient?.Connected ?? false) { tcpClient?.GetStream()?.Close(); }
            }
        }

        private void ServerConnected(IAsyncResult ar)
        {
            lock (monitor) { tcpClient.EndConnect(ar); }
            new Thread(() =>
            {
                try
                {
                    NetworkStream stream;
                    lock (monitor)
                    {
                        stream = tcpClient.GetStream();
                        SendMessage(new WelcomePlumberIAm(Username));
                    }
                    Handle(ReadMessages<IToAlchemy>(stream));
                }
                catch (Exception ex) { Console.Error.WriteLine(ex.Message); } // <- Ugly game jam code

                lock (monitor) { tcpClient = null; }
                invoke(() => ServerStopped?.Invoke());
            }).Start();
        }

        /// <summary>Handles incomming messages. This method is running own the thread created in <see cref="Connect(string, string, int)"/>.</summary>
        /// <param name="messages">Incomming messages.</param>
        private void Handle(IEnumerable<IToAlchemy> messages)
        {
            foreach (var message in messages)
            {
                switch (message)
                {
                    case ChatMessageToAlchemy chatMessage:
                        invoke(() => ReceivedMessage?.Invoke(chatMessage.Message));
                        break;
                    case SendIngredient ingredient:
                        invoke(() => ReceivedIngredient?.Invoke(ingredient.Ingredient, ingredient.Pipe));
                        break;
                    case StartLevel startLevel:
                        invoke(() => LevelStarted?.Invoke(LevelConfig.FromMutable(startLevel.Config)));
                        break;
                    case WelcomeAlchemistIAm welcome:
                        invoke(() => Connected?.Invoke(welcome.Username));
                        break;
                }
            }
        }

        private void SendMessage(IToPipes message)
        {
            lock (monitor)
            {
                if (tcpClient != null && tcpClient.Connected) { SendMessage(tcpClient.GetStream(), message); }
            }
        }

        public override void SendMessage(string message) => SendMessage(new ChatMessageToPipes(message));
        public void SendMoneyMaker(MoneyMaker moneyMaker, Pipe pipe) => SendMessage(new SendMoneyMaker(moneyMaker, pipe));
        public void GameOver(bool success) => SendMessage(new GameOver(success));
    }
}
