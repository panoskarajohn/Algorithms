namespace Problems.DP;

public class MinimumDifficultyJobSchedule
{
    #region TopDown Approach

    /// <summary>
    ///     Hard problem
    ///     Top down complexity O(n^2 * d), since there are n * d possible states and O(n) to
    ///     calculate the result for each state
    /// </summary>
    /// <param name="jobDifficulty"></param>
    /// <param name="days"></param>
    /// <returns></returns>
    public int MinDifficultyTopDown(int[] jobDifficulty, int days)
    {
        var n = jobDifficulty.Length;
        if (n < days)
            return -1;

        var mem = new int[n][];
        for (var i = 0; i < n; i++)
        {
            mem[i] = new int[days + 1];
            System.Array.Fill(mem[i], -1);
        }


        return MinDiff(0, days, jobDifficulty, mem);
    }

    private int MinDiff(int index, int daysRemaining, int[] jobDifficulty, int[][] mem)
    {
        if (mem[index][daysRemaining] != -1)
            return mem[index][daysRemaining];

        if (daysRemaining == 1)
        {
            var res = 0;
            for (var i = index; i < jobDifficulty.Length; i++)
                res = Math.Max(res, jobDifficulty[i]);

            return res;
        }

        var result = int.MaxValue;
        var dailyMaxJobDiff = 0;

        for (var j = index; j < jobDifficulty.Length - daysRemaining + 1; j++)
        {
            dailyMaxJobDiff = Math.Max(dailyMaxJobDiff, jobDifficulty[j]);
            result = Math.Min(result, 
                dailyMaxJobDiff + MinDiff(j + 1, daysRemaining - 1, jobDifficulty, mem));
        }

        mem[index][daysRemaining] = result;
        return result;
    }

    #endregion

    #region Bottom Up Approach

    public int MinDifficultyBottomUp(int[] jobDifficulty, int days)
    {
        int n = jobDifficulty.Length;

        int[][] dp = new int[days + 1][];
        for (int i = 0; i <= days; i++)
        {
            dp[i] = new int[n + 1];
            for (int j = 0; j < n; j++)
            {
                dp[i][j] = int.MaxValue;
            }
        }

        for (int daysRemaining = 1; daysRemaining <= days; daysRemaining++)
        {
            for (int i = 0; i < n - daysRemaining + 1; i++)
            {
                int dailyMaxDiff = 0;
                for (int j = i + 1; j < n - daysRemaining + 2; j++)
                {
                    dailyMaxDiff = Math.Max(dailyMaxDiff, jobDifficulty[j - 1]);
                    if (dp[daysRemaining - 1][j] != int.MaxValue)
                    {
                        dp[daysRemaining][i] = 
                            Math.Min(dp[daysRemaining][i], dailyMaxDiff + dp[daysRemaining - 1][j]);
                    }
                }
            }
        }

        return dp[days][0] < int.MaxValue ? dp[days][0] : -1;

    }

    #endregion

    #region Bottom up optimized

    public int MinDifficultyBottomUpOptimized(int[] jobDifficulty, int days)
    {
        int n = jobDifficulty.Length;
        int[] minDiffNextDay = new int[n + 1];
        for (int i = 0; i < n; i++)
            minDiffNextDay[i] = int.MaxValue;

        for (int daysRemaining = 1; daysRemaining <= days; daysRemaining++)
        {
            int[] minDiffCurrDay = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                minDiffCurrDay[i] = int.MaxValue;
            }

            for (int i = 0; i < n - daysRemaining + 1; i++)
            {
                int dailyMaxDiff = 0;

                for (int j = i + 1; j < n - daysRemaining + 2; j++)
                {
                    dailyMaxDiff = Math.Max(dailyMaxDiff, jobDifficulty[j - 1]);
                    if (minDiffNextDay[j] != int.MaxValue)
                    {
                        minDiffCurrDay[i] = Math.Min(minDiffCurrDay[i], dailyMaxDiff + minDiffNextDay[j]);
                    }
                }
            }

            minDiffNextDay = minDiffCurrDay;
        }

        return minDiffNextDay[0] < int.MaxValue ? minDiffNextDay[0] : -1;
    }
    

    #endregion
}