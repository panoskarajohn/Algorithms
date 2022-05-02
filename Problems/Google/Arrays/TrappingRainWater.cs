namespace Problems.Google.Arrays;

public class TrappingRainWater
{
    public static int Get(int[] heights)
    {
        int trapped = 0;
        int n = heights.Length;

        int[] maxLeft = new int[n];
        int[] maxRight = new int[n];
        int[] minLeftRight = new int[n];
        for (int i = 0; i < heights.Length; i++)
        {
            int prev = i - 1 >= 0 ? heights[i - 1] : 0;
            int maxLeftValueCompare = i - 1 > 0 ? maxLeft[i - 1] : 0;
            int maxLeftValue = Math.Max(prev, maxLeftValueCompare);
            maxLeft[i] = maxLeftValue;
        }

        for (int i = n - 1; i >= 0; i--)
        {
            int next = i + 1 < heights.Length ? heights[i + 1] : 0;
            int maxRightValueCompare = i + 1 < heights.Length ? maxRight[i + 1] : 0;
            int maxRightValue = Math.Max(next, maxRightValueCompare);
            maxRight[i] = maxRightValue;
        }

        for (int i = 0; i < n; i++)
        {
            var min = Math.Min(maxLeft[i], maxRight[i]);
            minLeftRight[i] = min;
        }

        for (int i = 0; i < n; i++)
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
        int trapped = 0;
        int n = height.Length;
        int left = 0;
        int right = n - 1;
        int heightLeft = height[left];
        int heightRight = height[right];
        
        while (left < right)
        {
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
        }

        return trapped;
    }
}