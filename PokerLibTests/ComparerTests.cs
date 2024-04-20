using FluentAssertions;
using PokerLib.Hands;
using PokerLib.Ranking.Comparers;

namespace PokerLibTests;

public class ComparerTests
{
    private readonly IComparerFactory _comparerFactory = new ComparerFactory();
    
    [Fact]
    public void Flush_Returns_HighCardComparer()
    {
        var comparer = _comparerFactory.Get(HandType.Flush);

        comparer.Should().BeAssignableTo<IComparer>();
        comparer.Should().BeOfType<HighCardComparer>();
    }
    
    [Fact]
    public void HighCard_Returns_HighCardComparer()
    {
        var comparer = _comparerFactory.Get(HandType.HighCard);

        comparer.Should().BeAssignableTo<IComparer>();
        comparer.Should().BeOfType<HighCardComparer>();
    }
    
    [Fact]
    public void Pair_Returns_PairComparer()
    {
        var comparer = _comparerFactory.Get(HandType.Pair);

        comparer.Should().BeAssignableTo<IComparer>();
        comparer.Should().BeOfType<PairComparer>();
    }
    
    [Fact]
    public void TwoPair_Returns_PairComparer()
    {
        var comparer = _comparerFactory.Get(HandType.TwoPairs);

        comparer.Should().BeAssignableTo<IComparer>();
        comparer.Should().BeOfType<PairComparer>();
    }
    
    [Fact]
    public void ThreeKind_Returns_ThreeKindComparer()
    {
        var comparer = _comparerFactory.Get(HandType.ThreeKind);

        comparer.Should().BeAssignableTo<IComparer>();
        comparer.Should().BeOfType<ThreeKindComparer>();
    }
}