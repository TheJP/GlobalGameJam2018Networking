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
        public override event Action<string> ReceivedMessage;

        private object monitor = new object();

        private TcpClient tcpClient;

        /// <param name="invoke">Action that invokes given actions on the main unity thread.</param>
        public AlchemyNetwork(Action<Action> invoke) : base(invoke) { }

        public void Connect(string username, string hostname, int port = DefaultPort)
        {
            lock (monitor)
            {
                if (tcpClient != null) { throw new InvalidOperationException($"Can't connect {nameof(AlchemyNetwork)} multiple times"); }
                tcpClient = new TcpClient();
                tcpClient.BeginConnect(hostname, port, ServerConnected, null);
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
                    lock (monitor) { stream = tcpClient.GetStream(); }
                    Handle(ReadMessages<IToAlchemy>(stream));
                }
                catch (Exception) { } // <- Ugly game jam code
                lock (monitor) { tcpClient = null; }
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
                }
            }
        }

        public override void SendMessage(string message)
        {
            lock (monitor)
            {
                if (tcpClient != null && tcpClient.Connected) { SendMessage(tcpClient.GetStream(), new ChatMessageToPipes(message)); }
            }
        }
    }
}
