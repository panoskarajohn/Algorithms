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
            var minHeight = 
                height[right] < height[left] 
                    ? height[right] : height[left];
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