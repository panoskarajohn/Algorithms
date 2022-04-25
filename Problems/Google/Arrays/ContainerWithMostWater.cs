namespace Problems.Google.Arrays;

public static class ContainerWithMostWater
{
    public static int MaxArea(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int result = 0;

        while (right > left) 
        {
            var distance = right - left;
            var minHeight = Math.Min(height[right], height[left]);
            var area = Area(distance, minHeight);

            if (height[left] < height[right])
                left++;
            else
                right--;

            result = Math.Max(result, area);
        }
        
        return result;
    }

    private static int Area(int side, int height) => side * height;
}