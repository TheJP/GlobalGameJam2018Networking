using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GlobalGameJam2018Networking
{
    /// <summary>
    /// Immutable type that describes the setup configuration of a level.
    /// Use <see cref="Builder(string, uint)"/> to create an instance.
    /// </summary>
    public class LevelConfig
    {
        public string Name { get; }
        public uint Difficulty { get; }
        private readonly List<Pipe> pipes;
        public ReadOnlyCollection<Pipe> Pipes => pipes.AsReadOnly();

        private LevelConfig(string name, uint difficulty, List<Pipe> pipes)
        {
            Name = name;
            Difficulty = difficulty;
            this.pipes = pipes;
        }

        public static LevelConfigBuilder Builder(string name, uint difficulty = 1) => new LevelConfigBuilder(name, difficulty);

        public class LevelConfigBuilder
        {
            private readonly string name;
            private readonly uint difficulty;
            private readonly List<Pipe> pipes = new List<Pipe>();

            internal LevelConfigBuilder(string name, uint difficulty)
            {
                this.name = name;
                this.difficulty = difficulty;
            }

            public LevelConfigBuilder AddPipe(PipeDirection direction, int order)
            {
                pipes.Add(new Pipe(pipes.Count + 1, direction, order));
                return this;
            }

            public LevelConfig Create() => new LevelConfig(name, difficulty, pipes);
        }
    }
}
