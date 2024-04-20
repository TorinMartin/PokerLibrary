using PokerLib.Cards;
using PokerLib.Hands;

namespace PokerLib.Ranking.Comparers;

public abstract class BaseComparer : IComparer
{
    public abstract RankResult Compare(IHand first, IHand second);

    protected (CardValue, CardValue) GetHighestPairs(IHand first, IHand second, int groupSize)
    {
        var firstResult = first.GroupHand(groupSize).Select(g => g.Key).OrderByDescending(v => v).FirstOrDefault();
        var secondResult = second.GroupHand(groupSize).Select(g => g.Key).OrderByDescending(v => v).FirstOrDefault();

        return (firstResult, secondResult);
    }
}