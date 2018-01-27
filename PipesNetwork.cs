using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using GlobalGameJam2018Networking.Protocol.MessageToAlchemy;
using GlobalGameJam2018Networking.Protocol.MessageToPipes;
using Newtonsoft.Json;

namespace GlobalGameJam2018Networking
{
    public class PipesNetwork : NetworkBase
    {
        public override event Action<string> ReceivedMessage;

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
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();
                tcpListener.BeginAcceptTcpClient(AcceptClient, null);
            }
        }

        private void AcceptClient(IAsyncResult result)
        {
            new Thread(new ThreadStart(() =>
            {
                try
                {
                    NetworkStream stream;
                    lock (monitor)
                    {
                        tcpClient = tcpListener.EndAcceptTcpClient(result);
                        stream = tcpClient.GetStream();
                    }
                    Handle(ReadMessages<IToPipes>(stream));
                }
                catch (Exception) { } // <- Ugly game jam code
                lock (monitor) { tcpClient = null; }

                // Accept a new client after this one quits
                tcpListener.BeginAcceptTcpClient(AcceptClient, null);
            })).Start();
        }

        /// <summary>Handles incomming messages. This method is running own the thread created in <see cref="AcceptClient(IAsyncResult)"/>.</summary>
        /// <param name="messages">Incomming messages.</param>
        private void Handle(IEnumerable<IToPipes> messages)
        {
            foreach(var message in messages)
            {
                switch (message)
                {
                    case ChatMessageToPipes chatMessage:
                        invoke(() => ReceivedMessage?.Invoke(chatMessage.Message));
                        break;
                }
            }
        }

        public override void SendMessage(string message)
        {
            lock (monitor)
            {
            }
        }
    }
}
