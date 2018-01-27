using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalGameJam2018Networking.Protocol.MessageToPipes
{
    internal class ChatMessageToPipes : IToPipes
    {
        public string Message { get; }

        public ChatMessageToPipes(string message)
        {
            Message = message;
        }
    }
}
