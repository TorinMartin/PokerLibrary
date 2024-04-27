namespace PokerLib.Hands.Comparers;

public interface IComparerFactory
{
    public IComparer<Hand> Get(HandType handType);
}

public class ComparerFactory : IComparerFactory
{
    public IComparer<Hand> Get(HandType handType) => handType switch
    {
        HandType.HighCard or HandType.Flush => new HighCardComparer(),
        HandType.Pair or HandType.TwoPairs => new PairComparer(),
        HandType.ThreeKind => new ThreeKindComparer(),
        _ => throw new Exception("Unknown rank argument provided")
    };
}