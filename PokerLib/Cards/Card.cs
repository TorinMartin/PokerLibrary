namespace PokerLib.Cards;

public interface ICard
{
    public CardSuit Suit { get; init; }
    public CardValue Value { get; init; }
}

public class Card : ICard
{
    public CardSuit Suit { get; init; }
    public CardValue Value { get; init; }

    public Card(CardSuit suit, CardValue value)
    {
        Suit = suit;
        Value = value;
    }
}