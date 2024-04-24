namespace PokerLib.Cards;

public interface IDeck
{
    public int Count();
    public void Shuffle();
    public ICard PullCard();
}

public class Deck : IDeck
{
    private Stack<ICard> _deck;

    private Deck(IEnumerable<ICard> cards)
    {
        _deck = new Stack<ICard>(cards);
    }

    private static IEnumerable<ICard> CreateSuit(CardSuit suit)
    {
        var set = new List<ICard>();

        var cardCount = Enum.GetNames(typeof(CardValue)).Length;
        for (var i = 1; i <= cardCount; i++)
        {
            set.Add(new Card(suit, (CardValue)i));
        }

        return set;
    }
    
    private static IEnumerable<ICard> Shuffle(IEnumerable<ICard> cards) => cards.OrderBy(c => Guid.NewGuid()).ToList();

    public static Deck CreateAndShuffle()
    {
        var cards = new List<ICard>();

        var suitCount = Enum.GetNames(typeof(CardSuit)).Length;
        for (var i = 1; i <= suitCount; i++)
        {
            cards.AddRange(CreateSuit((CardSuit)i));
        }

        return new Deck(Shuffle(cards));
    }
    
    public void Shuffle()
    {
        var cards = new List<ICard>(_deck.ToArray());
        _deck = new Stack<ICard>(Shuffle(cards));
    }

    public ICard PullCard() => _deck.Pop();

    public int Count() => _deck.Count;
}