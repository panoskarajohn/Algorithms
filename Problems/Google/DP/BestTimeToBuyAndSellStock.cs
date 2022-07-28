namespace Problems.Google.DP;

public class BestTimeToBuyAndSellStock
{
    public int MaxProfit(int[] prices)
    {
        var max = 0;
        var min = int.MaxValue;

        for (var i = 0; i < prices.Length; i++)
            if (prices[i] < min)
                min = prices[i];
            else
                max = Math.Max(max, prices[i] - min);

        return max;
    }
}