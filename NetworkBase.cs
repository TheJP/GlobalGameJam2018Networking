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
        private const int DefaultBufferSize = 1024;
        protected readonly Action<Action> invoke;

        public abstract event Action<string> ReceivedMessage;

        public NetworkBase(Action<Action> invoke)
        {
            this.invoke = invoke;
        }

        public abstract void SendMessage(string message);

        internal IEnumerable<T> ReadMessages<T>(NetworkStream stream) where T: IMessage
        {
            //var serializer = new JsonSerializer
            //{
            //    TypeNameHandling = TypeNameHandling.All
            //};
            //using (var reader = new StreamReader(stream, Encoding.UTF8, false, DefaultBufferSize, true))
            //using (var jsonTextReader = new JsonTextReader(reader))
            //{
            //    jsonTextReader.SupportMultipleContent = true;
            //    while (jsonTextReader.Read())
            //    {
            //        if (serializer.Deserialize<IMessage>(jsonTextReader) is T message) { yield return message; }
            //    }
            //}
            using (var reader = new StreamReader(stream, Encoding.UTF8, true, DefaultBufferSize, true))
            {
                while (true)
                {
                    var line = reader.ReadLine()?.Trim('\uFEFF');
                    if(line == null) { break; }
                    var o = JsonConvert.DeserializeObject(line, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
                    if(o is T message) { yield return message; }
                }
            }
        }

        internal void SendMessage<T>(NetworkStream stream, T message) where T: IMessage
        {
            var serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.All
            };
            using (var writer = new StreamWriter(stream, Encoding.UTF8, DefaultBufferSize, true))
            {
                var potential = JsonConvert.SerializeObject(message, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
                writer.WriteLine(potential);
                //serializer.Serialize(writer, message);
                writer.Flush();
            }
        }
    }
}
