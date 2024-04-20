using PokerLib.Hands;
using PokerLib.Ranking;
using PokerLib.Ranking.Comparers;

namespace PokerLibTests;

public class HandRankerTests
{
    private IHandRanker? _handRanker;
    
    [OneTimeSetUp]
    public void Setup()
    {
        var handEvaluator = new HandEvaluator();
        var comparerFactory = new ComparerFactory();
        _handRanker = new HandRanker(handEvaluator, comparerFactory);
    }

    [Test]
    public void ThreeKind_Beats_Pair()
    {
        var (pair, threeKind) = HandDealerMockGenerator.HigherPair().DealHands();

        var result = _handRanker?.RankHands(pair, threeKind);
        Assert.That(result?.Winner, Is.EqualTo(threeKind));
    }
    
    [Test]
    public void Higher_TwoPairs_Wins()
    {
        var (higher, lower) = HandDealerMockGenerator.HigherTwoPairs().DealHands();

        var result = _handRanker?.RankHands(higher, lower);
        Assert.That(result?.Winner, Is.EqualTo(higher));
    }

    [Test]
    public void Higher_ThreeKind_Wins()
    {
        var (higher, lower) = HandDealerMockGenerator.HigherThreeKind().DealHands();

        var result = _handRanker?.RankHands(higher, lower);
        Assert.That(result?.Winner, Is.EqualTo(higher));
    }

    [Test]
    public void HighCard_Ace_Wins()
    {
        var (highKing, highAce) = HandDealerMockGenerator.HighCardAce().DealHands();

        var result = _handRanker?.RankHands(highAce, highKing);
        Assert.That(result?.Winner, Is.EqualTo(highAce));
    }
    
    [Test]
    public void Higher_Pair_Ace_Wins()
    {
        var (lower, higher) = HandDealerMockGenerator.HigherPair().DealHands();

        var result = _handRanker?.RankHands(higher, lower);
        Assert.That(result?.Winner, Is.EqualTo(higher));
    }
    
    [Test]
    public void Flush_Beats_ThreeKind()
    {
        var (threeKind, flush) = HandDealerMockGenerator.FlushThreeKind().DealHands();

        var result = _handRanker?.RankHands(threeKind, flush);
        Assert.That(result?.Winner, Is.EqualTo(flush));
    }
    
    [Test]
    public void Higher_Flush_Wins()
    {
        var (flush, flushHigh) = HandDealerMockGenerator.HigherFlush().DealHands();

        var result = _handRanker?.RankHands(flush, flushHigh);
        Assert.That(result?.Winner, Is.EqualTo(flushHigh));
    }
    
    [Test]
    public void HighCard_Nine_Wins()
    {
        var (highCardNine, highCard) = HandDealerMockGenerator.HighCardNine().DealHands();

        var result = _handRanker?.RankHands(highCardNine, highCard);
        Assert.That(result?.Winner, Is.EqualTo(highCardNine));
    }
    
    [Test]
    public void Duplicate_Hands_Tie()
    {
        var (first, second) = HandDealerMockGenerator.Tie().DealHands();

        var result = _handRanker?.RankHands(first, second);
        Assert.Multiple(() =>
        {
            Assert.That(result?.Winner, Is.Null);
            Assert.That(result?.IsTie, Is.True);
        });
    }
}