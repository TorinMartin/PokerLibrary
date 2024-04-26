namespace PokerLib.Hands.Comparers;

public class HighCardComparer : IComparer
{
    public int Compare(Hand first, Hand second)
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
        
        if (firstHighest == secondHighest) return 0;
        
        return firstHighest?.Value > secondHighest?.Value ? -1 : 1;
    }
}