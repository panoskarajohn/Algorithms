namespace Problems.DP.OneDimension;

public class ClimbingStairs
{
    private readonly Dictionary<int, int> _cache = new();

    public int Climb(int n)
    {
        return GetDistinctWays(0, n);
    }

    private int GetDistinctWays(int currentStep, int steps)
    {
        if (currentStep == steps)
            return 1;

        if (currentStep > steps)
            return 0;

        if (_cache.ContainsKey(currentStep))
            return _cache[currentStep];


        var oneStep = GetDistinctWays(currentStep + 1, steps);
        var twoStep = GetDistinctWays(currentStep + 2, steps);
        var result = oneStep + twoStep;
        _cache.Add(currentStep, result);
        return result;
    }

    public int ClimbBottomUp(int n)
    {
        int one = 1, two = 1;

        for (var i = 0; i < n - 1; i++)
        {
            var temp = one;
            one = one + two;
            two = temp;
        }

        return one;
    }
}