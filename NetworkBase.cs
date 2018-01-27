using GlobalGameJam2018Networking.Protocol;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace GlobalGameJam2018Networking
{
    public abstract class NetworkBase
    {
        public const int DefaultPort = 505;

        protected readonly Action<Action> invoke;

        public abstract event Action<string> ReceivedMessage;

        public NetworkBase(Action<Action> invoke)
        {
            this.invoke = invoke;
        }

        public abstract void SendMessage(string message);

        internal IEnumerable<T> ReadMessages<T>(NetworkStream stream) where T: IMessage
        {
            var serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.All
            };
            using (var reader = new StreamReader(stream))
            using (var jsonTextReader = new JsonTextReader(reader))
            {
                jsonTextReader.SupportMultipleContent = true;
                while (jsonTextReader.Read())
                {
                    if (serializer.Deserialize<IMessage>(jsonTextReader) is T message) { yield return message; }
                }
            }
        }

        internal void SendMessage<T>(NetworkStream stream, T message) where T: IMessage
        {
            var serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.All
            };
            using (var writer = new StreamWriter(stream))
            {
                serializer.Serialize(writer, message);
            }
        }
    }
}
