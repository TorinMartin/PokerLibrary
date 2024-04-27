using Moq;
using PokerLib.Cards;
using PokerLib.Hands;
using PokerLib.Hands.Comparers;

namespace PokerLibTests;

public static class HandDealerMockGenerator
{
    private static IComparerFactory _comparerFactory = new ComparerFactory();
    
    private static IHandDealer CreateMockDealer(Hand hand)
    {
        var mock = new Mock<IHandDealer>();
        mock.Setup(handDealer => handDealer.DealHand()).Returns(hand);
        
        return mock.Object;
    }
    
    private static IHandDealer CreateMockDealer(Hand first, Hand second)
    {
        var mock = new Mock<IHandDealer>();
        mock.Setup(handDealer => handDealer.DealHands()).Returns(() => (first, second));
        
        return mock.Object;
    }

    public static IHandDealer CreateFlush()
    {
        var hand = new Hand(
            new Card(CardSuit.Spades, CardValue.Two),
            new Card(CardSuit.Spades, CardValue.Eight),
            new Card(CardSuit.Spades, CardValue.Four),
            new Card(CardSuit.Spades, CardValue.Queen),
            new Card(CardSuit.Spades, CardValue.Three),
            _comparerFactory
        );

        return CreateMockDealer(hand);
    }
    
    public static IHandDealer CreateThreeKind()
    {
        var hand = new Hand(
            new Card(CardSuit.Hearts, CardValue.Two),
            new Card(CardSuit.Spades, CardValue.Four),
            new Card(CardSuit.Clubs, CardValue.Four),
            new Card(CardSuit.Diamonds, CardValue.Three),
            new Card(CardSuit.Hearts, CardValue.Four),
            _comparerFactory
        );

        return CreateMockDealer(hand);
    }
    
    public static IHandDealer CreateTwoPair()
    {
        var hand = new Hand(

            new Card(CardSuit.Clubs, CardValue.Ace),
            new Card(CardSuit.Diamonds, CardValue.Ace),
            new Card(CardSuit.Hearts, CardValue.Queen),
            new Card(CardSuit.Clubs, CardValue.Queen),
            new Card(CardSuit.Clubs, CardValue.Ten),
            _comparerFactory
        );

        return CreateMockDealer(hand);
    }
    
    public static IHandDealer CreatePair()
    {
        var hand = new Hand(
            new Card(CardSuit.Hearts, CardValue.Two),
            new Card(CardSuit.Diamonds, CardValue.Two),
            new Card(CardSuit.Spades, CardValue.Five),
            new Card(CardSuit.Clubs, CardValue.Nine),
            new Card(CardSuit.Diamonds, CardValue.King),
            _comparerFactory
        );

        return CreateMockDealer(hand);
    }
    
    public static IHandDealer CreateHighCard()
    {
        var hand = new Hand(
            new Card(CardSuit.Spades, CardValue.Two),
            new Card(CardSuit.Diamonds, CardValue.Eight),
            new Card(CardSuit.Spades, CardValue.Four),
            new Card(CardSuit.Clubs, CardValue.Queen),
            new Card(CardSuit.Spades, CardValue.Three),
            _comparerFactory
        );

        return CreateMockDealer(hand);
    }

    public static IHandDealer FlushThreeKind()
    {
        var first = new Hand(
            new Card(CardSuit.Hearts, CardValue.Two),
            new Card(CardSuit.Spades, CardValue.Four),
            new Card(CardSuit.Clubs, CardValue.Four),
            new Card(CardSuit.Diamonds, CardValue.Three),
            new Card(CardSuit.Hearts, CardValue.Four),
            _comparerFactory
        );
        
        var second = new Hand(
            new Card(CardSuit.Spades, CardValue.Two),
            new Card(CardSuit.Spades, CardValue.Eight),
            new Card(CardSuit.Spades, CardValue.Ace),
            new Card(CardSuit.Spades, CardValue.Queen),
            new Card(CardSuit.Spades, CardValue.Three),
            _comparerFactory
        );
        
        return CreateMockDealer(first, second);
    }
    
    public static IHandDealer HigherFlush()
    {
        var first = new Hand(
            new Card(CardSuit.Clubs, CardValue.Three),
            new Card(CardSuit.Clubs, CardValue.Seven),
            new Card(CardSuit.Clubs, CardValue.Six),
            new Card(CardSuit.Clubs, CardValue.Jack),
            new Card(CardSuit.Clubs, CardValue.Four),
            _comparerFactory
        );
        
        var second = new Hand(
            new Card(CardSuit.Spades, CardValue.Two),
            new Card(CardSuit.Spades, CardValue.Eight),
            new Card(CardSuit.Spades, CardValue.Four),
            new Card(CardSuit.Spades, CardValue.Queen),
            new Card(CardSuit.Spades, CardValue.Three),
            _comparerFactory
        );
        
        return CreateMockDealer(first, second);
    }

    public static IHandDealer HigherThreeKind()
    {
        var first = new Hand(
            new Card(CardSuit.Clubs, CardValue.Ace),
            new Card(CardSuit.Diamonds, CardValue.Ace),
            new Card(CardSuit.Hearts, CardValue.Ace),
            new Card(CardSuit.Clubs, CardValue.Three),
            new Card(CardSuit.Clubs, CardValue.Ten),
            _comparerFactory
        );
        
        var second = new Hand(
            new Card(CardSuit.Clubs, CardValue.Queen),
            new Card(CardSuit.Diamonds, CardValue.Queen),
            new Card(CardSuit.Hearts, CardValue.Queen),
            new Card(CardSuit.Clubs, CardValue.Three),
            new Card(CardSuit.Clubs, CardValue.Ten),
            _comparerFactory
        );
        
        return CreateMockDealer(first, second);
    }

    public static IHandDealer HigherTwoPairs()
    {
        var first = new Hand(
            new Card(CardSuit.Clubs, CardValue.Ace),
            new Card(CardSuit.Diamonds, CardValue.Ace),
            new Card(CardSuit.Hearts, CardValue.Queen),
            new Card(CardSuit.Clubs, CardValue.Queen),
            new Card(CardSuit.Clubs, CardValue.Ten),
            _comparerFactory
        );
        
        var second = new Hand(
            new Card(CardSuit.Clubs, CardValue.Jack),
            new Card(CardSuit.Diamonds, CardValue.Jack),
            new Card(CardSuit.Hearts, CardValue.Nine),
            new Card(CardSuit.Clubs, CardValue.Nine),
            new Card(CardSuit.Clubs, CardValue.Ten),
            _comparerFactory
        );
        
        return CreateMockDealer(first, second);
    }
    
    public static IHandDealer HigherPair()
    {
        var first = new Hand(
            new Card(CardSuit.Clubs, CardValue.Two),
            new Card(CardSuit.Spades, CardValue.Two),
            new Card(CardSuit.Hearts, CardValue.Ace),
            new Card(CardSuit.Clubs, CardValue.Jack),
            new Card(CardSuit.Clubs, CardValue.Four),
            _comparerFactory
        );
        
        var second = new Hand(
            new Card(CardSuit.Hearts, CardValue.Ace),
            new Card(CardSuit.Diamonds, CardValue.Ace),
            new Card(CardSuit.Hearts, CardValue.Two),
            new Card(CardSuit.Spades, CardValue.Three),
            new Card(CardSuit.Spades, CardValue.Six),
            _comparerFactory
        );
        
        return CreateMockDealer(first, second);
    }
    
    public static IHandDealer HighCardAce()
    {
        var first = new Hand(
            new Card(CardSuit.Hearts, CardValue.Two),
            new Card(CardSuit.Diamonds, CardValue.Three),
            new Card(CardSuit.Spades, CardValue.Five),
            new Card(CardSuit.Clubs, CardValue.Nine),
            new Card(CardSuit.Diamonds, CardValue.King),
            _comparerFactory
        );
        
        var second = new Hand(
            new Card(CardSuit.Clubs, CardValue.Two),
            new Card(CardSuit.Hearts, CardValue.Three),
            new Card(CardSuit.Spades, CardValue.Four),
            new Card(CardSuit.Clubs, CardValue.Eight),
            new Card(CardSuit.Hearts, CardValue.Ace),
            _comparerFactory
        );
        
        return CreateMockDealer(first, second);
    }
    
    public static IHandDealer HighCardNine()
    {
        var first = new Hand(
            new Card(CardSuit.Hearts, CardValue.Two),
            new Card(CardSuit.Diamonds, CardValue.Three),
            new Card(CardSuit.Spades, CardValue.Five),
            new Card(CardSuit.Clubs, CardValue.Nine),
            new Card(CardSuit.Diamonds, CardValue.King),
            _comparerFactory
        );
        
        var second = new Hand(
            new Card(CardSuit.Clubs, CardValue.Two),
            new Card(CardSuit.Hearts, CardValue.Three),
            new Card(CardSuit.Spades, CardValue.Four),
            new Card(CardSuit.Clubs, CardValue.Eight),
            new Card(CardSuit.Hearts, CardValue.King),
            _comparerFactory
        );
        
        return CreateMockDealer(first, second);
    }
    
    public static IHandDealer Tie()
    {
        var first = new Hand(
            new Card(CardSuit.Hearts, CardValue.Two),
            new Card(CardSuit.Diamonds, CardValue.Three),
            new Card(CardSuit.Spades, CardValue.Five),
            new Card(CardSuit.Clubs, CardValue.Nine),
            new Card(CardSuit.Diamonds, CardValue.King),
            _comparerFactory
        );
        
        var second = new Hand(
            new Card(CardSuit.Diamonds, CardValue.Two),
            new Card(CardSuit.Hearts, CardValue.Three),
            new Card(CardSuit.Clubs, CardValue.Five),
            new Card(CardSuit.Spades, CardValue.Nine),
            new Card(CardSuit.Hearts, CardValue.King),
            _comparerFactory
        );
        
        return CreateMockDealer(first, second);
    }
}