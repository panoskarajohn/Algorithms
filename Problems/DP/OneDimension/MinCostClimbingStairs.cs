namespace Problems.DP.OneDimension;

public class MinCostClimbingStairs
{
    public int Get(int[] cost)
    {
        var n = cost.Length;
        if (n == 1)
            return cost[0];
        if (n == 2)
            return Math.Min(cost[0], cost[1]);

        var dp = new int[n + 1];
        dp[n] = 0;
        dp[n - 1] = Math.Min(cost[n - 1], cost[n - 2]);

        for (var i = n - 2; i >= 0; i--)
            dp[i] = cost[i] + Math.Min(dp[i + 1], dp[i + 2]);

        return Math.Min(dp[0], dp[1]);
    }
}