using PokerLib.Cards;

namespace PokerLib.Hands;

public interface IHandDealer
{
    public Hand DealHand();
    public (Hand, Hand) DealHands();
}

public class HandDealer : IHandDealer
{
    private Hand Deal(IDeck deck)
    {
        var cards = Enumerable.Range(0, Hand.HandSize).Select(_ => deck.PullCard()).ToList();
        return new Hand(cards);
    }

    public Hand DealHand()
    {
        var deck = Deck.CreateAndShuffle();
        return Deal(deck);
    }

    public (Hand, Hand) DealHands()
    {
        var deck = Deck.CreateAndShuffle();
        return (Deal(deck), Deal(deck));
    }
}