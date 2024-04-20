using PokerLib.Cards;

namespace PokerLib.Hands;

public interface IHand
{
    public List<ICard> Cards { get; init; }
    public bool RemoveCard(ICard cardToRemove);
    public ICard? GetHighestCard();
    public IEnumerable<IGrouping<CardValue, ICard>> GroupHand(int groupSize);
}

public class Hand : IHand
{
    public const int HandSize = 5;
    public List<ICard> Cards { get; init; }

    public Hand(List<ICard> cards)
    {
        if (cards.Count != HandSize) throw new ArgumentException($"Invalid number of cards provided. Hand must consist of {HandSize} cards.");
        Cards = cards;
    }

    public bool RemoveCard(ICard cardToRemove) => Cards.Remove(cardToRemove);
    
    public ICard? GetHighestCard() => Cards.MaxBy(c => c.Value);

    // Groups cards in hands by value and filters by provided group size arg
    public IEnumerable<IGrouping<CardValue, ICard>> GroupHand(int groupSize) => Cards.GroupBy(c => c.Value).Where(g => g.Count() == groupSize);
}