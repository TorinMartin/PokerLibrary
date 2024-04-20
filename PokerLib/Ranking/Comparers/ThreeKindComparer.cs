using PokerLib.Hands;

namespace PokerLib.Ranking.Comparers;

public class ThreeKindComparer : BaseComparer
{
    public override RankResult Compare(IHand first, IHand second)
    {
        var (firstHighest, secondHighest) = GetHighestPairs(first, second, 3);
        if (firstHighest == secondHighest) return new RankResult(true);

        var winner = firstHighest > secondHighest ? first : second;
        return new RankResult(Winner: winner);
    }
}