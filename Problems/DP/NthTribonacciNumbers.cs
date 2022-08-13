namespace Problems.DP;

public class NthTribonacciNumbers
{
    public int Get(int n)
    {
        if (n == 0)
            return 0;
        if (n == 1 || n == 2)
            return 1;

        var dp = new int[n + 1];
        dp[0] = 0;
        dp[1] = 1;
        dp[2] = 1;

        for (var i = 3; i < n + 1; i++) dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];

        return dp[^1];
    }
}