using Moq;
using PokerLib.Cards;
using PokerLib.Hands;

namespace PokerLibTests;

public class HandDealerTests
{
    [Test]
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
        Assert.That(dealer.DealHand, Throws.ArgumentException);
    }
}