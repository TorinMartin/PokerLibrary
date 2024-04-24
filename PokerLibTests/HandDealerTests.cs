using FluentAssertions;
using PokerLib.Hands;

namespace PokerLibTests;

public class HandDealerTests
{
    [Fact]
    public void Dealer_Deals_Correct_Num_Cards()
    {
        const int expected = Hand.HandSize;
        
        var dealer = new HandDealer();
        var hand = dealer.DealHand();
        var actual = hand.Cards.Count;

        actual.Should().Be(expected);
    }

    [Fact]
    public void Dealer_Deals_Correct_Hand_Sizes()
    {
        const int expected = Hand.HandSize;
        var dealer = new HandDealer();
        var (first, second) = dealer.DealHands();

        first.Cards.Count.Should().Be(expected);
        second.Cards.Count.Should().Be(expected);
    }
    
    [Fact]
    public void Invalid_Hand_Size_Throws()
    {
        var dealer = HandDealerMockGenerator.CreateInvalidHand();

        dealer.Invoking(d => d.DealHand())
            .Should()
            .Throw<ArgumentException>();
    }
}