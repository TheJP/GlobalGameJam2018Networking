namespace GlobalGameJam2018Networking
{
    public class Pipe
    {
        public int Id { get; }
        public PipeDirection Direction { get; }
        /// <summary>
        /// Order in which the pipes are displayed.
        /// Pipes with a smaller <see cref="Order"/> value are located closer to the top of the screen,
        /// pipes with higher values closer to the bottom.
        /// </summary>
        public int Order { get; }

        public Pipe(int id, PipeDirection direction, int order)
        {
            Id = id;
            Direction = direction;
            Order = order;
        }
    }
}
