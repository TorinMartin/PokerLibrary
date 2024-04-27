namespace PokerLib.Hands.Comparers;

public class PairComparer : BaseComparer
{
    protected override int CompareHands(Hand first, Hand second)
    {
        var (firstHighestPair, secondHighestPair) = GetHighestPairs(first, second, 2);
        if (firstHighestPair == secondHighestPair) return 0;

        return firstHighestPair > secondHighestPair ? 1 : -1;
    }
}