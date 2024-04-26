﻿using Moq;
using PokerLib.Cards;
using PokerLib.Hands;

namespace PokerLibTests;

public static class HandDealerMockGenerator
{
    private static IHandDealer CreateMockDealer(Func<List<Card>> create)
    {
        var mock = new Mock<IHandDealer>();
        mock.Setup(handDealer => handDealer.DealHand()).Returns(() => new Hand(create()));
        
        return mock.Object;
    }
    
    private static IHandDealer CreateMockDealer(Func<List<Card>> createFirst, Func<List<Card>> createSecond)
    {
        var mock = new Mock<IHandDealer>();
        mock.Setup(handDealer => handDealer.DealHands()).Returns(() => (new Hand(createFirst()), new Hand(createSecond())));
        
        return mock.Object;
    }

    public static IHandDealer CreateInvalidHand()
    {
        var hand = () => new List<Card>
        {
            new Card(CardSuit.Clubs, CardValue.Ace),
            new Card(CardSuit.Clubs, CardValue.Ace),
            new Card(CardSuit.Clubs, CardValue.Ace),
            new Card(CardSuit.Clubs, CardValue.Ace),
            new Card(CardSuit.Clubs, CardValue.Ace),
            new Card(CardSuit.Clubs, CardValue.Ace)
        };

        return CreateMockDealer(hand);
    }

    public static IHandDealer CreateFlush()
    {
        var hand = () => new List<Card>
        {
            new Card(CardSuit.Spades, CardValue.Two),
            new Card(CardSuit.Spades, CardValue.Eight),
            new Card(CardSuit.Spades, CardValue.Four),
            new Card(CardSuit.Spades, CardValue.Queen),
            new Card(CardSuit.Spades, CardValue.Three)
        };

        return CreateMockDealer(hand);
    }
    
    public static IHandDealer CreateThreeKind()
    {
        var hand = () => new List<Card>
        {
            new Card(CardSuit.Hearts, CardValue.Two),
            new Card(CardSuit.Spades, CardValue.Four),
            new Card(CardSuit.Clubs, CardValue.Four),
            new Card(CardSuit.Diamonds, CardValue.Three),
            new Card(CardSuit.Hearts, CardValue.Four)
        };

        return CreateMockDealer(hand);
    }
    
    public static IHandDealer CreateTwoPair()
    {
        var hand = () => new List<Card>
        {
            new Card(CardSuit.Clubs, CardValue.Ace),
            new Card(CardSuit.Diamonds, CardValue.Ace),
            new Card(CardSuit.Hearts, CardValue.Queen),
            new Card(CardSuit.Clubs, CardValue.Queen),
            new Card(CardSuit.Clubs, CardValue.Ten)
        };

        return CreateMockDealer(hand);
    }
    
    public static IHandDealer CreatePair()
    {
        var hand = () => new List<Card>
        {
            new Card(CardSuit.Hearts, CardValue.Two),
            new Card(CardSuit.Diamonds, CardValue.Two),
            new Card(CardSuit.Spades, CardValue.Five),
            new Card(CardSuit.Clubs, CardValue.Nine),
            new Card(CardSuit.Diamonds, CardValue.King)
        };

        return CreateMockDealer(hand);
    }
    
    public static IHandDealer CreateHighCard()
    {
        var hand = () => new List<Card>
        {
            new Card(CardSuit.Spades, CardValue.Two),
            new Card(CardSuit.Diamonds, CardValue.Eight),
            new Card(CardSuit.Spades, CardValue.Four),
            new Card(CardSuit.Clubs, CardValue.Queen),
            new Card(CardSuit.Spades, CardValue.Three)
        };

        return CreateMockDealer(hand);
    }

    public static IHandDealer FlushThreeKind()
    {
        var first = () => new List<Card>
        {
            new Card(CardSuit.Hearts, CardValue.Two),
            new Card(CardSuit.Spades, CardValue.Four),
            new Card(CardSuit.Clubs, CardValue.Four),
            new Card(CardSuit.Diamonds, CardValue.Three),
            new Card(CardSuit.Hearts, CardValue.Four)
        };

        var second = () => new List<Card>
        {
            new Card(CardSuit.Spades, CardValue.Two),
            new Card(CardSuit.Spades, CardValue.Eight),
            new Card(CardSuit.Spades, CardValue.Ace),
            new Card(CardSuit.Spades, CardValue.Queen),
            new Card(CardSuit.Spades, CardValue.Three)
        };
        
        return CreateMockDealer(first, second);
    }
    
    public static IHandDealer HigherFlush()
    {
        var first = () => new List<Card>
        {
            new Card(CardSuit.Clubs, CardValue.Three),
            new Card(CardSuit.Clubs, CardValue.Seven),
            new Card(CardSuit.Clubs, CardValue.Six),
            new Card(CardSuit.Clubs, CardValue.Jack),
            new Card(CardSuit.Clubs, CardValue.Four)
        };

        var second = () => new List<Card>
        {
            new Card(CardSuit.Spades, CardValue.Two),
            new Card(CardSuit.Spades, CardValue.Eight),
            new Card(CardSuit.Spades, CardValue.Four),
            new Card(CardSuit.Spades, CardValue.Queen),
            new Card(CardSuit.Spades, CardValue.Three)
        };
        
        return CreateMockDealer(first, second);
    }

    public static IHandDealer HigherThreeKind()
    {
        var first = () => new List<Card>
        {
            new Card(CardSuit.Clubs, CardValue.Ace),
            new Card(CardSuit.Diamonds, CardValue.Ace),
            new Card(CardSuit.Hearts, CardValue.Ace),
            new Card(CardSuit.Clubs, CardValue.Three),
            new Card(CardSuit.Clubs, CardValue.Ten)
        };

        var second = () => new List<Card>
        {
            new Card(CardSuit.Clubs, CardValue.Queen),
            new Card(CardSuit.Diamonds, CardValue.Queen),
            new Card(CardSuit.Hearts, CardValue.Queen),
            new Card(CardSuit.Clubs, CardValue.Three),
            new Card(CardSuit.Clubs, CardValue.Ten)
        };
        
        return CreateMockDealer(first, second);
    }

    public static IHandDealer HigherTwoPairs()
    {
        var first = () => new List<Card>
        {
            new Card(CardSuit.Clubs, CardValue.Ace),
            new Card(CardSuit.Diamonds, CardValue.Ace),
            new Card(CardSuit.Hearts, CardValue.Queen),
            new Card(CardSuit.Clubs, CardValue.Queen),
            new Card(CardSuit.Clubs, CardValue.Ten)
        };

        var second = () => new List<Card>
        {
            new Card(CardSuit.Clubs, CardValue.Jack),
            new Card(CardSuit.Diamonds, CardValue.Jack),
            new Card(CardSuit.Hearts, CardValue.Nine),
            new Card(CardSuit.Clubs, CardValue.Nine),
            new Card(CardSuit.Clubs, CardValue.Ten)
        };
        
        return CreateMockDealer(first, second);
    }
    
    public static IHandDealer HigherPair()
    {
        var first = () => new List<Card>
        {
            new Card(CardSuit.Clubs, CardValue.Two),
            new Card(CardSuit.Spades, CardValue.Two),
            new Card(CardSuit.Hearts, CardValue.Ace),
            new Card(CardSuit.Clubs, CardValue.Jack),
            new Card(CardSuit.Clubs, CardValue.Four)
        };

        var second = () => new List<Card>
        {
            new Card(CardSuit.Hearts, CardValue.Ace),
            new Card(CardSuit.Diamonds, CardValue.Ace),
            new Card(CardSuit.Hearts, CardValue.Two),
            new Card(CardSuit.Spades, CardValue.Three),
            new Card(CardSuit.Spades, CardValue.Six)
        };
        
        return CreateMockDealer(first, second);
    }
    
    public static IHandDealer HighCardAce()
    {
        var first = () => new List<Card>
        {
            new Card(CardSuit.Hearts, CardValue.Two),
            new Card(CardSuit.Diamonds, CardValue.Three),
            new Card(CardSuit.Spades, CardValue.Five),
            new Card(CardSuit.Clubs, CardValue.Nine),
            new Card(CardSuit.Diamonds, CardValue.King)
        };

        var second = () => new List<Card>
        {
            new Card(CardSuit.Clubs, CardValue.Two),
            new Card(CardSuit.Hearts, CardValue.Three),
            new Card(CardSuit.Spades, CardValue.Four),
            new Card(CardSuit.Clubs, CardValue.Eight),
            new Card(CardSuit.Hearts, CardValue.Ace)
        };
        
        return CreateMockDealer(first, second);
    }
    
    public static IHandDealer HighCardNine()
    {
        var first = () => new List<Card>
        {
            new Card(CardSuit.Hearts, CardValue.Two),
            new Card(CardSuit.Diamonds, CardValue.Three),
            new Card(CardSuit.Spades, CardValue.Five),
            new Card(CardSuit.Clubs, CardValue.Nine),
            new Card(CardSuit.Diamonds, CardValue.King)
        };

        var second = () => new List<Card>
        {
            new Card(CardSuit.Clubs, CardValue.Two),
            new Card(CardSuit.Hearts, CardValue.Three),
            new Card(CardSuit.Spades, CardValue.Four),
            new Card(CardSuit.Clubs, CardValue.Eight),
            new Card(CardSuit.Hearts, CardValue.King)
        };
        
        return CreateMockDealer(first, second);
    }
    
    public static IHandDealer Tie()
    {
        var first = () => new List<Card>
        {
            new Card(CardSuit.Hearts, CardValue.Two),
            new Card(CardSuit.Diamonds, CardValue.Three),
            new Card(CardSuit.Spades, CardValue.Five),
            new Card(CardSuit.Clubs, CardValue.Nine),
            new Card(CardSuit.Diamonds, CardValue.King)
        };

        var second = () => new List<Card>
        {
            new Card(CardSuit.Diamonds, CardValue.Two),
            new Card(CardSuit.Hearts, CardValue.Three),
            new Card(CardSuit.Clubs, CardValue.Five),
            new Card(CardSuit.Spades, CardValue.Nine),
            new Card(CardSuit.Hearts, CardValue.King)
        };
        
        return CreateMockDealer(first, second);
    }
}