namespace PokerLib.Hands;

public interface IHandEvaluator
{
    public HandType EvaluateHand(IHand hand);
}

public class HandEvaluator : IHandEvaluator
{
    private bool IsFlush(IHand hand) => hand.Cards.Select(c => c.Suit).Distinct().Count() == 1;
    private bool IsThreeKind(IHand hand) => hand.GroupHand(3).Count() == 1;
    private bool IsTwoPairs(IHand hand) => hand.GroupHand(2).Count() == 2;
    private bool IsPair(IHand hand) => hand.GroupHand(2).Count() == 1;
    public HandType EvaluateHand(IHand hand)
    {
        if (IsFlush(hand)) return HandType.Flush;
        if (IsThreeKind(hand)) return HandType.ThreeKind;
        if (IsTwoPairs(hand)) return HandType.TwoPairs;
        if (IsPair(hand)) return HandType.Pair;
        
        return HandType.HighCard;
    }
}