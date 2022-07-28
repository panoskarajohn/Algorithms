namespace Problems.Google.DP;

public class SplitArrayLargestSum
{
    /// <summary>
    ///     O(n log S) where S is the sum of the numbers
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="m"></param>
    /// <returns></returns>
    public int SplitArray(int[] nums, int m)
    {
        var left = nums.Max();
        var right = nums.Sum();

        var result = right;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (CanSplit(nums, mid, m))
            {
                result = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return result;
    }

    private bool CanSplit(int[] nums, int mid, int m)
    {
        var subArray = 0;
        var curSum = 0;

        foreach (var num in nums)
        {
            curSum += num;
            if (curSum > mid)
            {
                subArray++;
                curSum = num;
            }
        }

        return subArray + 1 <= m;
    }
}