using PokerLib.Cards;

namespace PokerLib.Hands.Comparers;

public abstract class BaseComparer : IComparer
{
    public abstract int Compare(Hand first, Hand second);

    protected (CardValue, CardValue) GetHighestPairs(Hand first, Hand second, int groupSize)
    {
        var firstResult = first.GroupHand(groupSize).Select(g => g.Key).OrderByDescending(v => v).FirstOrDefault();
        var secondResult = second.GroupHand(groupSize).Select(g => g.Key).OrderByDescending(v => v).FirstOrDefault();

        return (firstResult, secondResult);
    }
}