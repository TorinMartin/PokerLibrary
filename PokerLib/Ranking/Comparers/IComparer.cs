using PokerLib.Hands;

namespace PokerLib.Ranking.Comparers;

public interface IComparer
{
    public RankResult Compare(IHand first, IHand second);
}