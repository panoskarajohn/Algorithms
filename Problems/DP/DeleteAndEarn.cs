namespace Problems.DP;

public class DeleteAndEarn
{
    private readonly Dictionary<int, int> _points = new();

    /// <summary>
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int Do(int[] nums)
    {
        var n = nums.Length;
        var max = 0;

        foreach (var num in nums)
        {
            if (!_points.ContainsKey(num))
                _points[num] = 0;

            _points[num] += num;
            max = Math.Max(num, max);
        }

        var dp = new int[max + 1];
        dp[1] = _points.GetValueOrDefault(1);
        for (var i = 2; i < dp.Length; i++)
        {
            var gain = _points.GetValueOrDefault(i);
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + gain);
        }

        return dp[max];
    }
}