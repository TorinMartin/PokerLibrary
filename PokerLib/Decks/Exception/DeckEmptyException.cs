namespace PokerLib.Decks.Exception;

public class DeckEmptyException : System.Exception
{
    public DeckEmptyException()
    {
    }
    
    public DeckEmptyException(string message) : base(message)
    {
    }
}