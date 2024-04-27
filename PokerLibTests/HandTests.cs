using FluentAssertions;
using PokerLib.Cards;
using PokerLib.Hands;

namespace PokerLibTests;

public class HandTests
{
    [Fact]
    public void Highest_Card_Returned_Correctly()
    {
        var (_, hand) = HandDealerMockGenerator.HighCardAce().DealHands();
        var expected = CardValue.Ace;
        var actual = hand.GetHighestCard();

        actual.Should().NotBeNull();
        actual?.Value.Should().Be(expected);
    }

    [Fact]
    public void Card_Removed_Successfully()
    {
        var (_, hand) = HandDealerMockGenerator.HighCardAce().DealHands();
        var expected = CardValue.Ace;
        var actual = hand.GetHighestCard();

        actual.Should().NotBeNull();
        actual?.Value.Should().Be(expected);

        hand.RemoveCard(actual!);
        
        actual = hand.GetHighestCard();
        
        actual.Should().NotBeNull();
        actual.Should().NotBe(expected);
    }
    
    [Fact]
    public void Is_Flush()
    {
        // Discard second hand from mock generator
        var hand = HandDealerMockGenerator.CreateFlush().DealHand();
        var result = hand.Evaluate();

        result.Should().Be(HandType.Flush);
    }

    [Fact]
    public void Is_Three_of_a_Kind()
    {
        var hand = HandDealerMockGenerator.CreateThreeKind().DealHand();
        var result = hand.Evaluate();

        result.Should().Be(HandType.ThreeKind);
    }

    [Fact]
    public void Is_Two_Pairs()
    {
        var hand = HandDealerMockGenerator.CreateTwoPair().DealHand();
        var result = hand.Evaluate();

        result.Should().Be(HandType.TwoPairs);
    }

    [Fact]
    public void Is_Pair()
    {
        var hand = HandDealerMockGenerator.CreatePair().DealHand();
        var result = hand.Evaluate();
        
        result.Should().Be(HandType.Pair);
    }

    [Fact]
    public void Is_High_Card()
    {
        var hand = HandDealerMockGenerator.CreateHighCard().DealHand();
        var result = hand.Evaluate();

        result.Should().Be(HandType.HighCard);
    }
    
    [Fact]
    public void Pair_Beats_HighCard()
    {
        var pair = HandDealerMockGenerator.CreatePair().DealHand();
        var highCard = HandDealerMockGenerator.CreateHighCard().DealHand();

        pair.Should().BeGreaterThan(highCard);
    }

    [Fact]
    public void TwoPair_Beats_Pair()
    {
        var twoPair = HandDealerMockGenerator.CreateTwoPair().DealHand();
        var pair = HandDealerMockGenerator.CreatePair().DealHand();

        twoPair.Should().BeGreaterThan(pair);
    }
    
    [Fact]
    public void ThreeKind_Beats_Pair()
    {
        var threeKind = HandDealerMockGenerator.CreateThreeKind().DealHand();
        var pair = HandDealerMockGenerator.CreatePair().DealHand();

        threeKind.Should().BeGreaterThan(pair);
    }
    
    [Fact]
    public void Flush_Beats_ThreeKind()
    {
        var flush = HandDealerMockGenerator.CreateFlush().DealHand();
        var threeKind = HandDealerMockGenerator.CreateThreeKind().DealHand();

        flush.Should().BeGreaterThan(threeKind);
    }
    
    [Fact]
    public void Higher_TwoPairs_Wins()
    {
        var (higher, lower) = HandDealerMockGenerator.HigherTwoPairs().DealHands();

        higher.Should().BeGreaterThan(lower);
    }

    [Fact]
    public void Higher_ThreeKind_Wins()
    {
        var (higher, lower) = HandDealerMockGenerator.HigherThreeKind().DealHands();

        higher.Should().BeGreaterThan(lower);
    }

    // poker-challenge.md test cases
    [Fact]
    public void HighCard_Ace_Wins()
    {
        var (highKing, highAce) = HandDealerMockGenerator.HighCardAce().DealHands();

        highAce.Should().BeGreaterThan(highKing);
    }
    
    [Fact]
    public void Higher_Pair_Ace_Wins()
    {
        var (lower, higher) = HandDealerMockGenerator.HigherPair().DealHands();

        higher.Should().BeGreaterThan(lower);
    }
    
    [Fact]
    public void Higher_Flush_Wins()
    {
        var (flush, flushHigh) = HandDealerMockGenerator.HigherFlush().DealHands();

        flushHigh.Should().BeGreaterThan(flush);
    }
    
    [Fact]
    public void HighCard_Nine_Wins()
    {
        var (highCardNine, highCard) = HandDealerMockGenerator.HighCardNine().DealHands();

        highCardNine.Should().BeGreaterThan(highCard);
    }
    
    [Fact]
    public void Duplicate_Hands_Tie()
    {
        var (first, second) = HandDealerMockGenerator.Tie().DealHands();

        first.CompareTo(second).Should().Be(0);
    }
}