namespace Problems.Google.Sorting;

public class MedianOfTwoSortedArrays
{
    /// <summary>
    /// We want to do it efficiently
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public double FindMedian(int[] num1, int[] num2)
    {
        //Swap the arrays
        if (num2.Length < num1.Length)
            (num1, num2) = (num2, num1);

        var low = 0;
        var high = num1.Length;

        int combined = num1.Length + num2.Length;

        while (low <= high)
        {
            int partX = (low + high) / 2;
            int partY = (combined + 1) / 2 - partX;

            int leftX = GetMax(num1, partX);
            int rightX = GetMin(num1, partX);
            
            int leftY = GetMax(num2, partY);
            int rightY = GetMin(num2, partY);

            if (leftX <= rightY && leftY <= rightX)
            {
                if (combined % 2 == 0)
                    return (Math.Max(leftX, leftY) + Math.Min(rightX, rightY)) / 2.0;

                return Math.Max(leftX, leftY);
            }

            if (leftX > rightY)
            {
                high = partX - 1;
            }
            else
            {
                low = partX + 1;
            }
        }

        return -1;
    }

    private int GetMin(int[] nums, int partition)
    {
        if (partition == nums.Length)
            return int.MaxValue;

        return nums[partition];
    }

    private int GetMax(int[] nums, int partition)
    {
        if (partition == 0)
            return int.MinValue;
        
        return nums[partition - 1];
    }
}