namespace Problems.DP;

public class PaintFence
{
    private readonly Dictionary<int, int> _cache = new();

    public int NumWays(int n, int k)
    {
        return Dfs(n, k);
    }

    private int Dfs(int index, int k)
    {
        if (index == 1)
            return k;
        if (index == 2)
            return k * k;

        if (_cache.ContainsKey(index))
            return _cache[index];

        var ways = (k - 1) * (Dfs(index - 1, k) + Dfs(index - 2, k));
        _cache[index] = ways;

        return _cache[index];
    }

    public int NumWaysBottomUp(int n, int k)
    {
        var dp = new int[n + 1];
        dp[1] = k;
        dp[2] = k * k;

        for (var i = 3; i < n + 1; i++)
        {
            var ways = (k - 1) * (dp[i - 1] + dp[i - 2]);
            dp[i] = ways;
        }

        return dp[n];
    }
}