using PokerLib.Hands;
using PokerLib.Ranking;

namespace PokerLibTests;

public class HandEvaluatorTests
{
    private IHandEvaluator? _handEvaluator;
    
    [OneTimeSetUp]
    public void Setup()
    {
        _handEvaluator = new HandEvaluator();
    }

    [Test]
    public void Is_Flush()
    {
        // Discard second hand from mock generator
        var (hand, _) = HandDealerMockGenerator.HigherFlush().DealHands();
        var result = _handEvaluator?.EvaluateHand(hand);
        Assert.That(result, Is.EqualTo(HandType.Flush));
    }

    [Test]
    public void Is_Three_of_a_Kind()
    {
        var (hand, _) = HandDealerMockGenerator.HigherThreeKind().DealHands();
        var result = _handEvaluator?.EvaluateHand(hand);
        Assert.That(result, Is.EqualTo(HandType.ThreeKind));
    }

    [Test]
    public void Is_Two_Pairs()
    {
        var (hand, _) = HandDealerMockGenerator.HigherTwoPairs().DealHands();
        var result = _handEvaluator?.EvaluateHand(hand);
        Assert.That(result, Is.EqualTo(HandType.TwoPairs));
    }

    [Test]
    public void Is_Pair()
    {
        var (hand, _) = HandDealerMockGenerator.HigherPair().DealHands();
        var result = _handEvaluator?.EvaluateHand(hand);
        Assert.That(result, Is.EqualTo(HandType.Pair));
    }

    [Test]
    public void Is_High_Card()
    {
        var (hand, _) = HandDealerMockGenerator.HighCardAce().DealHands();
        var result = _handEvaluator?.EvaluateHand(hand);
        Assert.That(result, Is.EqualTo(HandType.HighCard));
    }
}