namespace Problems.DP;

public class LongestCommonSubsequence
{
    public int Get(string text1, string text2)
    {
        int n = text1.Length;
        int m = text2.Length;

        int[][] dp = new int[n + 1][];
        for (int i = 0; i < dp.Length; i++)
            dp[i] = new int[m + 1];

        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = m - 1; j >= 0; j--)
            {
                if (text1[i] == text2[j])
                {
                    dp[i][j] = 1 + dp[i + 1][j + 1];
                }
                else
                {
                    dp[i][j] = Math.Max(dp[i][j + 1], dp[i + 1][j]);
                }
            }
        }

        return dp[0][0];
    }
}