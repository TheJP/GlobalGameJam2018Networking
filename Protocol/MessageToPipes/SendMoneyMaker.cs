namespace GlobalGameJam2018Networking.Protocol.MessageToPipes
{
    internal class SendMoneyMaker : IToPipes
    {
        public MoneyMaker MoneyMaker { get; }
        public Pipe Pipe { get; }

        public SendMoneyMaker(MoneyMaker moneyMaker, Pipe pipe)
        {
            MoneyMaker = moneyMaker;
            Pipe = pipe;
        }
    }
}