namespace Problems.DP;

public class MaximumScoreFromPerformingMultiplications
{
    public int MaximumScore(int[] nums, int[] multipliers)
    {
        var n = nums.Length;
        var m = multipliers.Length;

        var dp = new int[m + 1][];
        for (var i = 0; i < dp.Length; i++)
            dp[i] = new int[m + 1];

        for (var i = m - 1; i >= 0; i--)
        for (var left = i; left >= 0; left--)
        {
            var mult = multipliers[i];
            var right = n - 1 - (i - left); //rightmost element
            dp[i][left] = Math.Max(mult * nums[left] + dp[i + 1][left + 1],
                mult * nums[right] + dp[i + 1][left]);
        }

        return dp[0][0];
    }
}