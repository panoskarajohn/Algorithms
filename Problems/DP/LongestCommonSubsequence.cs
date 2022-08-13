namespace Problems.DP;

public class LongestCommonSubsequence
{
    public int Get(string text1, string text2)
    {
        var n = text1.Length;
        var m = text2.Length;

        var dp = new int[n + 1][];
        for (var i = 0; i < dp.Length; i++)
            dp[i] = new int[m + 1];

        for (var i = n - 1; i >= 0; i--)
        for (var j = m - 1; j >= 0; j--)
            if (text1[i] == text2[j])
                dp[i][j] = 1 + dp[i + 1][j + 1];
            else
                dp[i][j] = Math.Max(dp[i][j + 1], dp[i + 1][j]);

        return dp[0][0];
    }
}