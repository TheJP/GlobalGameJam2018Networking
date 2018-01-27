namespace GlobalGameJam2018Networking
{
    public class MoneyMaker : IItem
    {
        public string Name { get; }
        public int GoldValue { get; }

        public ItemType Type { get; }

        public MoneyMaker(string name, int goldValue, ItemType type)
        {
            Name = name;
            GoldValue = goldValue;
            Type = type;
        }
    }
}
