namespace PokerLib.Hands.Comparers;

public class ThreeKindComparer : BaseComparer
{
    public override int Compare(Hand first, Hand second)
    {
        var (firstHighest, secondHighest) = GetHighestPairs(first, second, 3);
        if (firstHighest == secondHighest) return 0;

        return firstHighest > secondHighest ? 1 : -1;
    }
}