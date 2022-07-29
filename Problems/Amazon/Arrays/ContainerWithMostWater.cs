namespace Problems.Amazon.Arrays;

public class ContainerWithMostWater
{
    public int Get(int[] heights)
    {
        if (heights is null)
            return 0;

        var n = heights.Length;
        var left = 0;
        var right = n - 1;
        var maxArea = 0;

        while (left != right)
        {
            var distance = right - left;
            var currentHeight = Math.Min(heights[left], heights[right]);
            var area = distance * currentHeight;
            maxArea = Math.Max(maxArea, area);

            if (heights[left] < heights[right])
                left++;
            else
                right--;
        }

        return maxArea;
    }
}