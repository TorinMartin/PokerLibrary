using PokerLib.Hands;

namespace PokerLib.Ranking.Comparers;

public class HighCardComparer : IComparer
{
    public RankResult Compare(IHand first, IHand second)
    {
        var firstHighest = first.GetHighestCard();
        var secondHighest = second.GetHighestCard();

        // Loop until one card is greater than the other or we run out of cards (tie)
        while (firstHighest is not null && secondHighest is not null && firstHighest.Value == secondHighest.Value)
        {
            first.RemoveCard(firstHighest);
            second.RemoveCard(secondHighest);

            firstHighest = first.GetHighestCard();
            secondHighest = second.GetHighestCard();
        }
        
        if (firstHighest == secondHighest) return new RankResult(true);
        
        var winner = firstHighest?.Value > secondHighest?.Value ? first : second;
        return new RankResult(Winner: winner);
    }
}