using PokerLib.Hands;
using PokerLib.Ranking.Comparers;

namespace PokerLib.Ranking;

public record RankResult(bool IsTie = false, IHand? Winner = null);

public interface IHandRanker
{
    public RankResult RankHands(IHand first, IHand second);
}

public class HandRanker : IHandRanker
{
    private readonly IHandEvaluator _handEvaluator;
    private readonly IComparerFactory _comparerFactory;
    
    public HandRanker(IHandEvaluator handEvaluator, IComparerFactory comparerFactory)
    {
        _handEvaluator = handEvaluator;
        _comparerFactory = comparerFactory;
    }
    
    public RankResult RankHands(IHand first, IHand second)
    {
        var firstEval = _handEvaluator.EvaluateHand(first);
        var secondEval = _handEvaluator.EvaluateHand(second);

        // Clear winner, return with higher eval
        if (firstEval != secondEval)
        {
            var winner = firstEval > secondEval ? first : second;
            return new RankResult(Winner: winner);
        }

        // Factory method to grab appropriate comparer class based on first hands evaluation (we know they are the same here).
        var comparer = _comparerFactory.Get(firstEval);
        var result = comparer.Compare(first, second);

        return result;
    }
}