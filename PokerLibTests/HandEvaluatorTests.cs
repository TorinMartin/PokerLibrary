using FluentAssertions;
using PokerLib.Hands;

namespace PokerLibTests;

public class HandEvaluatorTests
{
    private readonly IHandEvaluator _handEvaluator = new HandEvaluator();
    
    [Fact]
    public void Is_Flush()
    {
        // Discard second hand from mock generator
        var hand = HandDealerMockGenerator.CreateFlush().DealHand();
        var result = _handEvaluator.EvaluateHand(hand);

        result.Should().Be(HandType.Flush);
    }

    [Fact]
    public void Is_Three_of_a_Kind()
    {
        var hand = HandDealerMockGenerator.CreateThreeKind().DealHand();
        var result = _handEvaluator.EvaluateHand(hand);

        result.Should().Be(HandType.ThreeKind);
    }

    [Fact]
    public void Is_Two_Pairs()
    {
        var hand = HandDealerMockGenerator.CreateTwoPair().DealHand();
        var result = _handEvaluator.EvaluateHand(hand);

        result.Should().Be(HandType.TwoPairs);
    }

    [Fact]
    public void Is_Pair()
    {
        var hand = HandDealerMockGenerator.CreatePair().DealHand();
        var result = _handEvaluator.EvaluateHand(hand);
        
        result.Should().Be(HandType.Pair);
    }

    [Fact]
    public void Is_High_Card()
    {
        var hand = HandDealerMockGenerator.CreateHighCard().DealHand();
        var result = _handEvaluator.EvaluateHand(hand);

        result.Should().Be(HandType.HighCard);
    }
}