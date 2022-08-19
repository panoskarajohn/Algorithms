namespace Problems.DP;

public class MaxLengthRepeatedSubArray
{
    /// <summary>
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>
    public int FindLengthBottomUp(int[] nums1, int[] nums2)
    {
        var answer = 0;
        var n = nums1.Length;
        var m = nums2.Length;

        var memo = new int[n + 1][];
        for (var i = 0; i < n + 1; i++) memo[i] = new int[m + 1];

        for (var i = n - 1; i >= 0; i--)
        for (var j = m - 1; j >= 0; j--)
            if (nums1[i] == nums2[j])
            {
                memo[i][j] = memo[i + 1][j + 1] + 1;
                answer = Math.Max(answer, memo[i][j]);
            }

        return answer;
    }
}