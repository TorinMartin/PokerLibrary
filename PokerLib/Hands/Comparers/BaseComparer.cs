using PokerLib.Cards;

namespace PokerLib.Hands.Comparers;

public abstract class BaseComparer : IComparer<Hand>
{
    protected abstract int CompareHands(Hand first, Hand second);
    public int Compare(Hand? first, Hand? second)
    {
        if (first is null || second is null)
        {
            throw new ArgumentNullException(first is null ? nameof(first) : nameof(second));
        }

        return CompareHands(first, second);
    }

    protected (CardValue, CardValue) GetHighestPairs(Hand first, Hand second, int groupSize)
    {
        var firstResult = first.GroupHand(groupSize).Select(g => g.Key).OrderByDescending(v => v).FirstOrDefault();
        var secondResult = second.GroupHand(groupSize).Select(g => g.Key).OrderByDescending(v => v).FirstOrDefault();

        return (firstResult, secondResult);
    }
}