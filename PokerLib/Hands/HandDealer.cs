using PokerLib.Decks;
using PokerLib.Hands.Comparers;

namespace PokerLib.Hands;

public interface IHandDealer
{
    public Hand DealHand();
    public (Hand, Hand) DealHands();
}

public class HandDealer : IHandDealer
{
    private readonly IComparerFactory _comparerFactory;
    
    public HandDealer(IComparerFactory comparerFactory)
    {
        _comparerFactory = comparerFactory;
    }
    
    private Hand Deal(IDeck deck)
    {
        var one = deck.PullCard();
        var two = deck.PullCard();
        var three = deck.PullCard();
        var four = deck.PullCard();
        var five = deck.PullCard();
        
        return new Hand(one, two, three, four, five, _comparerFactory);
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