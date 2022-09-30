namespace Problems.Google.DP;

public class MaximumSubarray
{
    /// <summary>
    ///     Dynamic programming Kadanes algorithm
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int MaxSubArray(int[] nums)
    {
        // Initialize our variables using the first element
        var currentSubarray = nums[0];
        var maxSubarray = nums[0];

        //start with the second element since we already used the first one
        for (var i = 1; i < nums.Length; i++)
        {
            var num = nums[i];
            //if current subarray is negative, throw it away. Otherwise, keep adding it.

            currentSubarray = Math.Max(num, currentSubarray + num);
            maxSubarray = Math.Max(maxSubarray, currentSubarray);
        }

        return maxSubarray;
    }

    public int MaxSubArray2(int[] nums)
    {
        // Initialize our variables using the first element
        var currentSubarray = nums[0];
        var maxSubarray = nums[0];

        //start with the second element since we already used the first one
        for (var i = 1; i < nums.Length; i++)
        {
            currentSubarray = Math.Max(currentSubarray, 0);
            currentSubarray += nums[i];
            maxSubarray = Math.Max(maxSubarray, currentSubarray);
        }

        return maxSubarray;
    }
}