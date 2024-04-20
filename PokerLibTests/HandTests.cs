using FluentAssertions;
using PokerLib.Cards;

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
}