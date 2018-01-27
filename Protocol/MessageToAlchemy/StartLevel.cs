namespace GlobalGameJam2018Networking.Protocol.MessageToAlchemy
{
    internal class StartLevel : IToAlchemy
    {
        public LevelConfig Config { get; }

        public StartLevel(LevelConfig config)
        {
            Config = config;
        }
    }
}