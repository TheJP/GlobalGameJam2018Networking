namespace GlobalGameJam2018Networking.Protocol.MessageToAlchemy
{
    internal class WelcomeAlchemistIAm : IToAlchemy
    {
        public string Username { get; }

        public WelcomeAlchemistIAm(string username)
        {
            Username = username;
        }

    }
}