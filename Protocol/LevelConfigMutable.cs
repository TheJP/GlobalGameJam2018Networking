using System.Collections.Generic;

namespace GlobalGameJam2018Networking.Protocol
{
    class LevelConfigMutable
    {
        public string Name { get; set; }
        public uint Difficulty { get; set; }
        public Dictionary<int, Pipe> Pipes { get; set; }

        public LevelConfigMutable(string name, uint difficulty, Dictionary<int, Pipe> pipes)
        {
            Name = name;
            Difficulty = difficulty;
            Pipes = pipes;
        }
    }
}
