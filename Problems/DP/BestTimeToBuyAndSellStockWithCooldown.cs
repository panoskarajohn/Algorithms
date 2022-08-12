namespace Problems.DP;

public class BestTimeToBuyAndSellStockWithCooldown
{
    private readonly Dictionary<(int, bool), int> _cache = new();

    public int MaxProfitWithCooldown(int[] prices)
    {
        return Dfs(prices, 0, true);
    }

    private int Dfs(in int[] prices, int i, bool buying)
    {
        if (i >= prices.Length)
            return 0;

        if (_cache.ContainsKey((i, buying)))
            return _cache[(i, buying)];

        var cooldown = Dfs(prices, i + 1, true);

        if (buying)
        {
            var buy = -prices[i] + Dfs(prices, i + 1, false);
            _cache[(i, buying)] = Math.Max(buy, cooldown);
        }
        else
        {
            var sell = prices[i] + Dfs(prices, i + 2, true);
            _cache[(i, buying)] = Math.Max(sell, cooldown);
        }

        return _cache[(i, buying)];
    }

    public int MaxProfitWithCooldownOpt(int[] prices)
    {
        int sold = int.MinValue, held = int.MinValue, reset = 0;

        foreach (var price in prices)
        {
            var preSold = sold;

            sold = held + price;
            held = Math.Max(held, reset - price);
            reset = Math.Max(reset, preSold);
        }

        return Math.Max(sold, reset);
    }
}