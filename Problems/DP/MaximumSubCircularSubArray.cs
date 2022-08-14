namespace Problems.DP;

public class MaximumSubCircularSubArray
{
    /// <summary>
    ///     Kadane's algorithm
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int MaxSubarraySumCircular(int[] nums)
    {
        var totalSum = 0;
        var maxEndingAt = 0;
        var minEndingAt = 0;
        var minSum = int.MaxValue;
        var maxSum = int.MinValue;

        foreach (var num in nums)
        {
            totalSum += num;
            maxEndingAt = Math.Max(maxEndingAt + num, num);
            maxSum = Math.Max(maxEndingAt, maxSum);

            minEndingAt = Math.Min(minEndingAt + num, num);
            minSum = Math.Min(minEndingAt, minSum);
        }

        if (maxSum > 0) return Math.Max(maxSum, totalSum - minSum);

        return maxSum;
    }
}