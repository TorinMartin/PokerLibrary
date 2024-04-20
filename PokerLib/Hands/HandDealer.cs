using PokerLib.Cards;

namespace PokerLib.Hands;

public interface IHandDealer
{
    public Hand DealHand();
    public (Hand, Hand) DealHands();
}

public class HandDealer : IHandDealer
{
    /// <summary>
    /// Method to randomly generate a hand of 5 cards
    /// </summary>
    /// <returns>Hand object containing 5 randomized cards</returns>
    public Hand DealHand()
    {
        var cards = new List<ICard>();

        var random = new Random();
        for (var i = 0; i < Hand.HandSize; i++)
        {
            var suit = random.Next(1, 4);
            var value = random.Next(1, 13);
            
            cards.Add(new Card((CardSuit)suit, (CardValue)value));
        }

        return new Hand(cards);
    }

    /// <summary>
    /// Method to generate a pair of hands each containing 5 randomly generated cards
    /// </summary>
    /// <returns>Tuple containing a pair of hands each containing 5 randomly generated cards</returns>
    public (Hand, Hand) DealHands() => (DealHand(), DealHand());
}