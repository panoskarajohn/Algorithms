namespace Problems.DP;

public class MaximalSquare
{
    public int Get(char[][] matrix)
    {
        int n = matrix.Length;
        int m = matrix[0].Length;

        int[][] dp = new int[n + 1][];
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = new int[m + 1];
        }

        var max = 0;


        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = m - 1; j >= 0; j--)
            {
                if (matrix[i][j] == '1')
                {
                    dp[i][j] = 1 + Math.Min(dp[i + 1][j], 
                        Math.Min(dp[i + 1][j + 1] , dp[i][j + 1]));
                }

                max = Math.Max(max, dp[i][j]);
            }
        }

        return max * max;
    }
}