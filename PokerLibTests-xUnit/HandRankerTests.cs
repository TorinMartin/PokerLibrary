using FluentAssertions;
using PokerLib.Hands;
using PokerLib.Ranking;
using PokerLib.Ranking.Comparers;

namespace PokerLibTests;

public class HandRankerTests
{
    private readonly IHandRanker _handRanker;

    public HandRankerTests()
    {
        var handEvaluator = new HandEvaluator();
        var comparerFactory = new ComparerFactory();
        _handRanker = new HandRanker(handEvaluator, comparerFactory);
    }
    
    [Fact]
    public void ThreeKind_Beats_Pair()
    {
        var (pair, threeKind) = HandDealerMockGenerator.HigherPair().DealHands();
        var result = _handRanker.RankHands(pair, threeKind);

        result.Winner.Should().NotBeNull();
        result.Winner.Should().Be(threeKind);
    }
    
    [Fact]
    public void Higher_TwoPairs_Wins()
    {
        var (higher, lower) = HandDealerMockGenerator.HigherTwoPairs().DealHands();
        var result = _handRanker.RankHands(higher, lower);

        result.Winner.Should().NotBeNull();
        result.Winner.Should().Be(higher);
    }

    [Fact]
    public void Higher_ThreeKind_Wins()
    {
        var (higher, lower) = HandDealerMockGenerator.HigherThreeKind().DealHands();
        var result = _handRanker.RankHands(higher, lower);
        
        result.Winner.Should().NotBeNull();
        result.Winner.Should().Be(higher);
    }

    [Fact]
    public void HighCard_Ace_Wins()
    {
        var (highKing, highAce) = HandDealerMockGenerator.HighCardAce().DealHands();
        var result = _handRanker.RankHands(highAce, highKing);
        
        result.Winner.Should().NotBeNull();
        result.Winner.Should().Be(highAce);
    }
    
    [Fact]
    public void Higher_Pair_Ace_Wins()
    {
        var (lower, higher) = HandDealerMockGenerator.HigherPair().DealHands();
        var result = _handRanker.RankHands(higher, lower);
        
        result.Winner.Should().NotBeNull();
        result.Winner.Should().Be(higher);
    }
    
    [Fact]
    public void Flush_Beats_ThreeKind()
    {
        var (threeKind, flush) = HandDealerMockGenerator.FlushThreeKind().DealHands();
        var result = _handRanker.RankHands(threeKind, flush);
        
        result.Winner.Should().NotBeNull();
        result.Winner.Should().Be(flush);
    }
    
    [Fact]
    public void Higher_Flush_Wins()
    {
        var (flush, flushHigh) = HandDealerMockGenerator.HigherFlush().DealHands();
        var result = _handRanker.RankHands(flush, flushHigh);
        
        result.Winner.Should().NotBeNull();
        result.Winner.Should().Be(flushHigh);
    }
    
    [Fact]
    public void HighCard_Nine_Wins()
    {
        var (highCardNine, highCard) = HandDealerMockGenerator.HighCardNine().DealHands();
        var result = _handRanker.RankHands(highCardNine, highCard);
        
        result.Winner.Should().NotBeNull();
        result.Winner.Should().Be(highCardNine);
    }
    
    [Fact]
    public void Duplicate_Hands_Tie()
    {
        var (first, second) = HandDealerMockGenerator.Tie().DealHands();
        var result = _handRanker.RankHands(first, second);

        result.Winner.Should().BeNull();
        result.IsTie.Should().BeTrue();
    }
}