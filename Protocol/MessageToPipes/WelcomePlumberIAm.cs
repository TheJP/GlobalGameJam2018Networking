namespace GlobalGameJam2018Networking.Protocol.MessageToPipes
{
    internal class WelcomePlumberIAm : IToPipes
    {
        public string Username { get; }

        public WelcomePlumberIAm(string username)
        {
            Username = username;
        }
    }
}