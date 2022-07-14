namespace Problems.Google.Recursion;

public class ClimbingStairs
{
    private Dictionary<int, int> _cache = new();
    public int GetDistinctWays(int steps)
    {
        
        if (_cache.ContainsKey(steps))
            return _cache[steps];
        
        if (steps < 2)
            return 1;

        var oneStep = GetDistinctWays(steps - 1); 
        var twoStep =  GetDistinctWays(steps - 2);
        var result = oneStep + twoStep;
        _cache.Add(steps, result);
        return result;
    }
}