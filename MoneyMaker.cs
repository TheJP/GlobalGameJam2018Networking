namespace GlobalGameJam2018Networking
{
    public class MoneyMaker
    {
        public string Name { get; }
        public int GoldValue { get; }

        public MoneyMaker(string name, int goldValue)
        {
            Name = name;
            GoldValue = goldValue;
        }
    }
}
