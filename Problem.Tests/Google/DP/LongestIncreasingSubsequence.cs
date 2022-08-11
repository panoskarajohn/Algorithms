using System;
using System.Linq;
using System.Net;

namespace Problem.Tests.Google.DP;

public class LongestIncreasingSubsequence
{
    /// <summary>
    ///     O(n ^ 2)
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int Get(int[] nums)
    {
        var n = nums.Length;

        var lis = new int[n];
        System.Array.Fill(lis, 1);
        var max = 1;

        for (var i = n - 1; i >= 0; i--)
        for (var j = i + 1; j < n; j++)
            if (nums[i] < nums[j])
            {
                lis[i] = Math.Max(lis[i], 1 + lis[j]);
                max = Math.Max(max, lis[i]);
            }


        return max;
    }

    /// <summary>
    ///     O(n log(n))
    ///     Improve with binary search
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int GetOpt(int[] nums)
    {
        int n = nums.Length;
        var subSequence = new List<int>();
        subSequence.Add(nums[0]);

        for (int i = 1; i < n; i++)
        {
            int num = nums[i];
            if (num > subSequence[^1])
            {
                subSequence.Add(num);
            }
            else
            {
                int getRight = BinarySearch(subSequence, num);
                subSequence[getRight] = num;
            }
        }

        return subSequence.Count;
    }

    private int BinarySearch(List<int> subSequence, int num)
    {
        var left = 0;
        var right = subSequence.Count - 1;
        int mid;

        while (left < right)
        {
            mid = (left + right) / 2;
            
            if (subSequence[mid] == num)
                return mid;

            if (subSequence[mid] < num)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }

}