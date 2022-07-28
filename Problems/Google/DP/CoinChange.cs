namespace Problems.Google.DP;

public class CoinChange
{
    /// <summary>
    ///     Dynamic programming approach
    /// </summary>
    /// <param name="coins"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public int Get(int[] coins, int amount)
    {
        Span<int> dp = stackalloc int[amount + 1];
        dp.Fill(amount + 1);
        dp[0] = 0;


        foreach (var coin in coins)
            for (var i = coin; i <= amount; i++)
                dp[i] = Math.Min(dp[i], dp[i - coin] + 1);

        return dp[amount] == amount + 1 ? -1 : dp[amount];
    }

    public int GetNumberOfCombinations(int[] coins, int amount)
    {
        Span<int> dp = stackalloc int[amount + 1];
        dp[0] = 1;


        foreach (var coin in coins)
            for (var i = coin; i <= amount; i++)
                dp[i] += dp[i - coin];

        return dp[amount];
    }
}