using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
