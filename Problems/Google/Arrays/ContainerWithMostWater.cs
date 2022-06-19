namespace Problems.Google.Arrays;

public static class ContainerWithMostWater
{
    public static int MaxArea(int[] height)
    {
        var left = 0;
        var right = height.Length - 1;
        var result = 0;

        while (right > left)
        {
            var distance = right - left;
            var minHeight =
                height[right] < height[left]
                    ? height[right]
                    : height[left];
            var area = distance * minHeight;

            if (height[left] < height[right])
                left++;
            else
                right--;

            result = result > area ? result : area;
        }

        return result;
    }
}