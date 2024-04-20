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
        var (hand, _) = HandDealerMockGenerator.HigherFlush().DealHands();
        var result = _handEvaluator.EvaluateHand(hand);

        result.Should().Be(HandType.Flush);
    }

    [Fact]
    public void Is_Three_of_a_Kind()
    {
        var (hand, _) = HandDealerMockGenerator.HigherThreeKind().DealHands();
        var result = _handEvaluator.EvaluateHand(hand);

        result.Should().Be(HandType.ThreeKind);
    }

    [Fact]
    public void Is_Two_Pairs()
    {
        var (hand, _) = HandDealerMockGenerator.HigherTwoPairs().DealHands();
        var result = _handEvaluator.EvaluateHand(hand);

        result.Should().Be(HandType.TwoPairs);
    }

    [Fact]
    public void Is_Pair()
    {
        var (hand, _) = HandDealerMockGenerator.HigherPair().DealHands();
        var result = _handEvaluator.EvaluateHand(hand);
        
        result.Should().Be(HandType.Pair);
    }

    [Fact]
    public void Is_High_Card()
    {
        var (hand, _) = HandDealerMockGenerator.HighCardAce().DealHands();
        var result = _handEvaluator.EvaluateHand(hand);

        result.Should().Be(HandType.HighCard);
    }
}