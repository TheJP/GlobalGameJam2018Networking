namespace GlobalGameJam2018Networking.Protocol.MessageToAlchemy
{
    internal class SendIngredient : IToAlchemy
    {
        public Ingredient Ingredient { get; }
        public Pipe Pipe { get; }

        public SendIngredient(Ingredient ingredient, Pipe pipe)
        {
            Ingredient = ingredient;
            Pipe = pipe;
        }
    }
}