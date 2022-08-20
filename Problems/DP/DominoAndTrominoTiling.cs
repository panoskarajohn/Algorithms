namespace Problems.DP;

/// <summary>
///     This is a hard problem
/// </summary>
public class DominoAndTrominoTiling
{
    private const int Mod = 1_000_000_007;
    private int[][] _dp;

    public int NumTilings(int n)
    {
        _dp = new int[n + 1][];
        for (int i = 0; i < n + 1; i++)
        {
            _dp[i] = new int[3];
            System.Array.Fill(_dp[i], -1);
        }
        
        return GetWays(n, 0);
    }

    int GetWays(int n, int state)
    {
        if (n == 0 && state == 0)
            return 1;

        if (n <= 0)
            return 0;

        if (_dp[n][state] != -1)
            return _dp[n][state];

        long ways = 0;
        if (state == 0)
        {
            ways += GetWays(n - 1, 0);
            ways += GetWays(n - 2, 0);
            ways += GetWays(n - 1, 1);
            ways += GetWays(n - 1, 2);
        }
        else if (state == 1)
        {
            ways += GetWays(n - 2, 0);
            ways += GetWays(n - 1, 2);
        }
        else
        {
            ways += GetWays(n - 2, 0);
            ways += GetWays(n - 1, 1);
        }

        return _dp[n][state] = (int)(ways % Mod);
    }
}