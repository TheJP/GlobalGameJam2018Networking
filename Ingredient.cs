namespace GlobalGameJam2018Networking
{
    public class Ingredient : IItem
    {
        public ItemType Type { get; }
        public IngredientColour Colour { get; }

        public Ingredient(ItemType type, IngredientColour colour)
        {
            Type = type;
            Colour = colour;
        }
    }
}
