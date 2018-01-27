using System.Linq;
using System.Collections.Generic;

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
        private readonly Dictionary<int, Pipe> pipes;
        public IEnumerable<Pipe> Pipes => pipes.Values;

        public Pipe this[int pipeIndex] => pipes[pipeIndex];

        private LevelConfig(string name, uint difficulty, List<Pipe> pipes)
        {
            Name = name;
            Difficulty = difficulty;
            this.pipes = pipes.ToDictionary(pipe => pipe.Id);
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
