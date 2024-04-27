namespace PokerLib.Cards;

public class Card
{
    public CardSuit Suit { get; init; }
    public CardValue Value { get; init; }

    public Card(CardSuit suit, CardValue value)
    {
        Suit = suit;
        Value = value;
    }
}