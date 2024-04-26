namespace PokerLib.Cards;

public interface IDeck
{
    public int Count();
    public void Shuffle();
    public Card PullCard();
}

public class Deck : IDeck
{
    private Stack<Card> _deck;

    private Deck(IEnumerable<Card> cards)
    {
        _deck = new Stack<Card>(cards);
    }

    private static IEnumerable<Card> CreateSuit(CardSuit suit)
    {
        var set = new List<Card>();

        var cardCount = Enum.GetNames(typeof(CardValue)).Length;
        for (var i = 1; i <= cardCount; i++)
        {
            set.Add(new Card(suit, (CardValue)i));
        }

        return set;
    }
    
    private static IEnumerable<Card> Shuffle(IEnumerable<Card> cards) => cards.OrderBy(c => Guid.NewGuid()).ToList();

    public static Deck CreateAndShuffle()
    {
        var cards = new List<Card>();

        var suitCount = Enum.GetNames(typeof(CardSuit)).Length;
        for (var i = 1; i <= suitCount; i++)
        {
            cards.AddRange(CreateSuit((CardSuit)i));
        }

        return new Deck(Shuffle(cards));
    }
    
    public void Shuffle()
    {
        var cards = new List<Card>(_deck.ToArray());
        _deck = new Stack<Card>(Shuffle(cards));
    }

    public Card PullCard() => _deck.Pop();

    public int Count() => _deck.Count;
}