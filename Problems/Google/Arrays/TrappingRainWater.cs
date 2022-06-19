namespace Problems.Google.Arrays;

public class TrappingRainWater
{
    public static int Get(int[] heights)
    {
        var trapped = 0;
        var n = heights.Length;

        var maxLeft = new int[n];
        var maxRight = new int[n];
        var minLeftRight = new int[n];
        for (var i = 0; i < heights.Length; i++)
        {
            var prev = i - 1 >= 0 ? heights[i - 1] : 0;
            var maxLeftValueCompare = i - 1 > 0 ? maxLeft[i - 1] : 0;
            var maxLeftValue = Math.Max(prev, maxLeftValueCompare);
            maxLeft[i] = maxLeftValue;
        }

        for (var i = n - 1; i >= 0; i--)
        {
            var next = i + 1 < heights.Length ? heights[i + 1] : 0;
            var maxRightValueCompare = i + 1 < heights.Length ? maxRight[i + 1] : 0;
            var maxRightValue = Math.Max(next, maxRightValueCompare);
            maxRight[i] = maxRightValue;
        }

        for (var i = 0; i < n; i++)
        {
            var min = Math.Min(maxLeft[i], maxRight[i]);
            minLeftRight[i] = min;
        }

        for (var i = 0; i < n; i++)
        {
            var waterTrapped = minLeftRight[i] - heights[i];
            if (waterTrapped < 0)
                waterTrapped = 0;
            trapped += waterTrapped;
        }

        return trapped;
    }

    public static int GetTwoPointersApproach(int[] height)
    {
        var trapped = 0;
        var n = height.Length;
        var left = 0;
        var right = n - 1;
        var heightLeft = height[left];
        var heightRight = height[right];

        while (left < right)
            if (heightLeft < heightRight)
            {
                left++;
                heightLeft = Math.Max(heightLeft, height[left]);
                trapped += heightLeft - height[left];
            }
            else
            {
                right--;
                heightRight = Math.Max(heightRight, height[right]);
                trapped += heightRight - height[right];
            }

        return trapped;
    }
}