namespace GlobalGameJam2018Networking.Protocol.MessageToPipes
{
    internal class GameOver : IToPipes
    {
        public bool Success { get; }

        public GameOver(bool success)
        {
            Success = success;
        }
    }
}