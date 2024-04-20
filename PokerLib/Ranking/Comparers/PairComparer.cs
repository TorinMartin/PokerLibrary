using PokerLib.Hands;

namespace PokerLib.Ranking.Comparers;

public class PairComparer : BaseComparer
{
    public override RankResult Compare(IHand first, IHand second)
    {
        var (firstHighestPair, secondHighestPair) = GetHighestPairs(first, second, 2);
        if (firstHighestPair == secondHighestPair) return new RankResult(true);

        var winner = firstHighestPair > secondHighestPair ? first : second;
        return new RankResult(Winner: winner);
    }
}