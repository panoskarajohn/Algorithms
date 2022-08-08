namespace Problems.DP;

public class MaximumScoreFromPerformingMultiplications
{
    public int MaximumScore(int[] nums, int[] multipliers)
    {
        int n = nums.Length;
        int m = multipliers.Length;
        
        int[][] dp = new int[m + 1][];
        for (int i = 0; i < dp.Length; i++)
            dp[i] = new int[m + 1];
        
        for (int i = m - 1; i >= 0; i--) {
            for (int left = i; left >= 0; left--) {
                int mult = multipliers[i];
                int right = n - 1 - (i - left); //rightmost element
                dp[i][left] = Math.Max(mult * nums[left] + dp[i + 1][left + 1], 
                    mult * nums[right] + dp[i + 1][left]);
            }
        }
        
        return dp[0][0];
    }
}