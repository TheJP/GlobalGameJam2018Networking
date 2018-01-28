namespace GlobalGameJam2018Networking.Protocol.MessageToAlchemy
{
    internal class StartLevel : IToAlchemy
    {
        public LevelConfigMutable Config { get; }

        public StartLevel(LevelConfigMutable config)
        {
            Config = config;
        }
    }
}