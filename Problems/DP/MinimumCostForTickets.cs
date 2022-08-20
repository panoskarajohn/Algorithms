namespace Problems.DP;

public class MinimumCostForTickets
{
    private readonly Dictionary<int, int> _cache = new();
    private readonly Dictionary<int, int> _daysCosts = new();

    public int MinCostTicketsTopDown(int[] days, int[] costs)
    {
        _daysCosts[1] = costs[0];
        _daysCosts[7] = costs[1];
        _daysCosts[30] = costs[2];
        return Dfs(days, 0);
    }

    private int Dfs(int[] days, int index)
    {
        if (index == days.Length) return 0;
        if (_cache.ContainsKey(index)) return _cache[index];

        _cache[index] = int.MaxValue;

        foreach (var daysFromCost in _daysCosts.Keys)
        {
            var j = index;
            while (j < days.Length && days[j] < days[index] + daysFromCost) j += 1;

            _cache[index] = Math.Min(_cache[index], _daysCosts[daysFromCost] + Dfs(days, j));
        }

        return _cache[index];
    }


    public int MinCostTicketsBottomUp(int[] days, int[] costs)
    {
        var n = days.Length;
        var dp = new Dictionary<int, int>();
        _daysCosts[1] = costs[0];
        _daysCosts[7] = costs[1];
        _daysCosts[30] = costs[2];

        for (var i = n - 1; i >= 0; i--)
        {
            dp[i] = int.MaxValue;
            foreach (var daysCosts in _daysCosts.Keys)
            {
                var j = i;
                while (j < n && days[j] < days[i] + daysCosts) j++;

                dp[i] = Math.Min(dp[i], _daysCosts[daysCosts] + dp.GetValueOrDefault(j));
            }
        }

        return dp[0];
    }
}