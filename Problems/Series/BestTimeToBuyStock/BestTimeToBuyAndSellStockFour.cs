namespace Problems.Series.BestTimeToBuyStock;

public class BestTimeToBuyAndSellStockFour
{
    private int[][][] _memo;

    private int[] _prices;

    /// <summary>
    ///     Hard problem
    /// </summary>
    /// <param name="prices"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int MaxProfitInKTransactionsTopDown(int[] prices, int k)
    {
        _prices = prices;
        _memo = new int[prices.Length][][];

        for (var i = 0; i < prices.Length; i++)
        {
            _memo[i] = new int[k + 1][];
            for (var j = 0; j < k + 1; j++) _memo[i][j] = new int[2];
        }


        return DP(0, k, 0);
    }

    private int DP(int index, int transactions, int holding)
    {
        if (transactions == 0 || index == _prices.Length) return 0;

        if (_memo[index][transactions][holding] == 0)
        {
            var doNothing = DP(index + 1, transactions, holding);
            int doSomething;

            if (holding == 1)
                doSomething = _prices[index] + DP(index + 1, transactions - 1, 0);
            else
                doSomething = -_prices[index] + DP(index + 1, transactions, 1);

            _memo[index][transactions][holding] = Math.Max(doNothing, doSomething);
        }

        return _memo[index][transactions][holding];
    }

    public int MaxProfitInKTransactionsBottomUp(int[] prices, int k)
    {
        var n = prices.Length;
        var dp = new int[n + 1][][];

        for (var i = 0; i < n + 1; i++)
        {
            dp[i] = new int[k + 1][];
            for (var j = 0; j < k + 1; j++)
                dp[i][j] = new int[2];
        }

        for (var i = n - 1; i >= 0; i--)
        for (var transaction = 1; transaction < k + 1; transaction++)
        for (var holding = 0; holding < 2; holding++)
        {
            var doNothing = dp[i + 1][transaction][holding];
            int doSomething;

            if (holding == 1)
                doSomething = prices[i] + dp[i + 1][transaction - 1][0];
            else
                doSomething = -prices[i] + dp[i + 1][transaction][1];

            dp[i][transaction][holding] = Math.Max(doNothing, doSomething);
        }

        return dp[0][k][0];
    }
}