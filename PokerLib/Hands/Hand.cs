using PokerLib.Cards;
using PokerLib.Ranking.Comparers;

namespace PokerLib.Hands;

public class Hand : IComparable<Hand>
{
    public const int HandSize = 5;
    private readonly List<Card> _cards;
    private readonly IComparerFactory _comparerFactory;

    public Hand(Card one, Card two, Card three, Card four, Card five, IComparerFactory comparerFactory)
    {
        _cards = new List<Card> { one, two, three, four, five };
        _comparerFactory = comparerFactory;
    }

    public void AddCard(Card cardToAdd) => _cards.Add(cardToAdd);
    public bool RemoveCard(Card cardToRemove) => _cards.Remove(cardToRemove);
    public int CountCards() => _cards.Count;
    public Card? GetHighestCard() => _cards.MaxBy(c => c.Value);
    public HandType Evaluate()
    {
        if (IsFlush()) return HandType.Flush;
        if (IsThreeKind()) return HandType.ThreeKind;
        if (IsTwoPairs()) return HandType.TwoPairs;
        if (IsPair()) return HandType.Pair;
        
        return HandType.HighCard;
    }
    
    // Groups cards in hands by value and filters by provided group size arg
    public IEnumerable<IGrouping<CardValue, Card>> GroupHand(int groupSize) => _cards.GroupBy(c => c.Value).Where(g => g.Count() == groupSize);

    public int CompareTo(Hand? other)
    {
        if (other is null) throw new ArgumentNullException(nameof(other), "Cannot compare to null");
        
        var firstEval = Evaluate();
        var secondEval = other.Evaluate();

        // Clear winner, return with higher eval
        if (firstEval != secondEval) return firstEval > secondEval ? -1 : 1;

        // Factory method to grab appropriate comparer class based on first hands evaluation (we know they are the same here).
        var comparer = _comparerFactory.Get(firstEval);
        
        return comparer.Compare(this, other);
    }
    
    private bool IsFlush() => _cards.Select(c => c.Suit).Distinct().Count() == 1;
    private bool IsThreeKind() => GroupHand(3).Count() == 1;
    private bool IsTwoPairs() => GroupHand(2).Count() == 2;
    private bool IsPair() => GroupHand(2).Count() == 1;
}