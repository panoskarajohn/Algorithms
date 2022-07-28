namespace Problems.Google.DP;

public class MaximumProductSubarray
{
    public int MaxProduct(int[] nums)
    {
        // Initialize our variables using the first element
        var maxSubarray = nums[0];
        var minSubarray = nums[0];
        var max = maxSubarray;

        //start with the second element since we already used the first one
        for (var i = 1; i < nums.Length; i++)
        {
            var current = nums[i];
            var tempMax = Math.Max(current, Math.Max(current * maxSubarray, current * minSubarray));
            minSubarray = Math.Min(current, Math.Min(current * maxSubarray, current * minSubarray));

            maxSubarray = tempMax;
            max = Math.Max(max, maxSubarray);
        }

        return max;
    }
}