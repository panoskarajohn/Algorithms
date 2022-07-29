namespace Problems.Amazon.Arrays;

public class RankElements
{
    public int[] Rank(int[] nums)
    {
        var n = nums.Length;
        var temp = nums.ToArray();

        System.Array.Sort(temp);
        var result = new int[n];

        var map = new Dictionary<int, int>();
        for (var i = 0; i < n; i++)
        {
            var current = temp[i];
            if (map.ContainsKey(current))
                continue;

            map[current] = i + 1;
        }

        for (var i = 0; i < n; i++)
        {
            var current = nums[i];
            result[i] = map[current];
        }

        return result;
    }
}