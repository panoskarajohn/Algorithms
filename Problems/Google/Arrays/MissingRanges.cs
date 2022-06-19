namespace Problems.Google.Arrays;

public class MissingRanges
{
    public static IList<string> GetNotOptimal(int[] nums, int lower, int upper)
    {
        var list = new List<string>();

        if (nums.Length == 0)
        {
            list.Add(ArrowRange(lower, upper));
            return list;
        }

        var start = 0;
        var n = nums.Length;
        if (nums[0] > lower)
        {
            list.Add(ArrowRange(lower, nums[0] - 1));
            start++;
        }

        for (var i = 0; i < n - 1; i++)
        {
            var diff = nums[i + 1] - nums[i];

            if (diff > 1)
            {
                var leftRange = nums[i] + 1;
                var rightRange = nums[i + 1] - 1;
                list.Add(ArrowRange(leftRange, rightRange));
            }
        }

        if (n - 1 >= 0 && nums[n - 1] < upper) list.Add(ArrowRange(nums[n - 1] + 1, upper));

        return list;
    }

    public static IList<string> Get(int[] nums, int lower, int upper)
    {
        var list = new List<string>();
        var prev = lower - 1;

        for (var i = 0; i <= nums.Length; i++)
        {
            var current = i < nums.Length ? nums[i] : upper + 1;
            if (prev + 1 <= current - 1)
                list.Add(ArrowRange(prev + 1, current - 1));
            prev = current;
        }

        return list;
    }

    private static string ArrowRange(int num1, int num2)
    {
        return num1 == num2 ? num1.ToString() : $"{num1}->{num2}";
    }
}