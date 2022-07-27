namespace Problems.Google.DP;

public class MaximumSubarray
{
    /// <summary>
    /// Dynamic programming Kadanes algorithm
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int MaxSubArray(int[] nums)
    {
        // Initialize our variables using the first element
        var currentSubarray = nums[0];
        var maxSubarray = nums[0];
        
        //start with the second element since we already used the first one
        for (int i = 1; i < nums.Length; i++)
        {
            int num = nums[i];
            //if current subarray is negative, throw it away. Otherwise, keep adding it.

            currentSubarray = Math.Max(num, currentSubarray + num);
            maxSubarray = Math.Max(maxSubarray, currentSubarray);
        }
        
        return maxSubarray;
    }
}