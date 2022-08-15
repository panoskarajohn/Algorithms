namespace Problems.Series.BestTimeToBuyStock;

public class BestTimeToBuyAndSellStockWithTransactionFee
{
    private readonly Dictionary<(int, bool), int> _cache = new();

    public int MaxProfitWithFee(int[] prices, int fee)
    {
        var n = prices.Length;
        if (n <= 1)
            return 0;
        var dp = new int[n][];
        for (var i = 0; i < n; i++)
            dp[i] = new int[2];

        dp[0][0] = 0;
        dp[0][1] = -prices[0] - fee; // means we bought it today

        for (var i = 1; i < n; i++)
        {
            dp[i][0] = Math.Max(dp[i - 1][0], dp[i - 1][1] + prices[i]);
            dp[i][1] = Math.Max(dp[i - 1][1], dp[i - 1][0] - prices[i] - fee);
        }

        return dp[^1][0];
    }

    public int MatProfitWithFeeTopDown(int[] prices, int fee)
    {
        return Dfs(prices, 0, fee, true);
    }

    private int Dfs(int[] prices, int index, int fee, bool buying)
    {
        if (index >= prices.Length)
            return 0;

        if (_cache.ContainsKey((index, buying)))
            return _cache[(index, buying)];

        var max = 0;
        if (buying)
        {
            var buy = -prices[index] - fee + Dfs(prices, index + 1, fee, false);
            var notBuy = Dfs(prices, index + 1, fee, true);
            max = Math.Max(buy, notBuy);
        }
        else
        {
            var sell = prices[index] + Dfs(prices, index + 1, fee, true);
            var notSell = Dfs(prices,index + 1,fee ,false);
            max = Math.Max(sell, notSell);
            
        }

        _cache[(index, buying)] = max;

        return max;
    }
}