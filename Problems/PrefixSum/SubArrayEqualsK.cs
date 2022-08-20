namespace Problems.PrefixSum;

public class SubArrayEqualsK
{
    /// <summary>
    ///     Prefix Sum
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int SubarraySum(int[] nums, int k)
    {
        var n = nums.Length;
        var map = new Dictionary<int, int>();
        var count = 0;
        var sum = 0;

        map[0] = 1; //case of 1 + 1 + 1 - 3 = 0
        for (var i = 0; i < n; i++)
        {
            sum += nums[i];
            var search = sum - k;
            if (map.ContainsKey(search)) count += map[search];

            if (!map.ContainsKey(sum))
                map[sum] = 0;
            map[sum]++;
        }

        return count;
    }
}