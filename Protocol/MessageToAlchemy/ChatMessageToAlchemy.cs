using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalGameJam2018Networking.Protocol.MessageToAlchemy
{
    internal class ChatMessageToAlchemy : IToAlchemy
    {
        public string Message { get; }

        public ChatMessageToAlchemy(string message)
        {
            Message = message;
        }
    }
}
