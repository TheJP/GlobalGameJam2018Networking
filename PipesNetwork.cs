using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace GlobalGameJam2018Networking
{
    public class PipesNetwork : NetworkBase
    {
        public override event Action<string> ReceivedMessage;

        private TcpListener tcpListener;

        /// <param name="invoke">Action that invokes given actions on the main unity thread.</param>
        public PipesNetwork(Action<Action> invoke) : base(invoke) { }

        public void Start(string username, int port = DefaultPort)
        {
            if (tcpListener != null) { throw new InvalidOperationException($"Can't start {nameof(PipesNetwork)} multiple times"); }
            tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(AcceptClient, null);
        }

        private void AcceptClient(IAsyncResult result)
        {
            new Thread(new ThreadStart(() =>
            {
                var tcpClient = tcpListener.EndAcceptTcpClient(result);
                var serializer = new JsonSerializer();
                using (var reader = new StreamReader(tcpClient.GetStream()))
                using (var jsonTextReader = new JsonTextReader(reader))
                {
                    jsonTextReader.SupportMultipleContent = true;
                    while (jsonTextReader.Read())
                    {
                        serializer.Deserialize<object>(jsonTextReader);
                    }
                }
            })).Start();
        }

        public override void SendMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
