using FluentAssertions;
using Moq;
using PokerLib.Cards;
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
    public void Invalid_Hand_Size_Throws()
    {
        var mock = new Mock<IHandDealer>();
        mock.Setup(handDealer => handDealer.DealHand()).Returns(() =>
        {
            var cards = new List<ICard>()
            {
                new Card(CardSuit.Clubs, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.Ace)
            };

            return new Hand(cards);
        });

        var dealer = mock.Object;

        dealer
            .Invoking(d => d.DealHand())
            .Should()
            .Throw<ArgumentException>();
    }
}