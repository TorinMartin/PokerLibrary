using FluentAssertions;
using PokerLib.Hands;
using PokerLib.Hands.Comparers;

namespace PokerLibTests;

public class HandDealerTests
{
    private readonly IComparerFactory _comparerFactory;
    
    public HandDealerTests()
    {
        _comparerFactory = new ComparerFactory();
    }
    
    [Fact]
    public void Dealer_Deals_Correct_Num_Cards()
    {
        const int expected = Hand.HandSize;
        
        var dealer = new HandDealer(_comparerFactory);
        var hand = dealer.DealHand();
        var actual = hand.CountCards();

        actual.Should().Be(expected);
    }

    [Fact]
    public void Dealer_Deals_Correct_Hand_Sizes()
    {
        const int expected = Hand.HandSize;
        var dealer = new HandDealer(_comparerFactory);
        var (first, second) = dealer.DealHands();

        first.CountCards().Should().Be(expected);
        second.CountCards().Should().Be(expected);
    }
}