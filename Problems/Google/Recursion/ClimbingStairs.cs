namespace Problems.Google.Recursion;

public class ClimbingStairs
{
    private Dictionary<int, int> _cache = new();

    public int Climb(int n)
    {
        return GetDistinctWays(0, n);
    }
    
    int GetDistinctWays(int currentStep,int steps)
    {
        if (currentStep == steps)
            return 1;
        
        if (currentStep > steps)
            return 0;
        
        if (_cache.ContainsKey(currentStep))
            return _cache[currentStep];

        
        var oneStep = GetDistinctWays(currentStep + 1, steps); 
        var twoStep =  GetDistinctWays(currentStep + 2, steps);
        var result = oneStep + twoStep;
        _cache.Add(currentStep, result);
        return result;
    }
}