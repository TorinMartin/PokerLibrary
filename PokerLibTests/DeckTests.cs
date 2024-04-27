using FluentAssertions;
using PokerLib.Decks;

namespace PokerLibTests;

public class DeckTests
{
    [Fact]
    public void Deck_Contains_52_Cards()
    {
        var deck = Deck.CreateAndShuffle();
        deck.Count().Should().Be(52);
    }
}