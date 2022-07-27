namespace Problems.Google.Sorting;

public class PeakIndexInAMountainArray
{
    /// <summary>
    ///     Using BS
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public int Get(int[] arr)
    {
        if (arr is null || arr.Length < 3)
            return 0;

        var left = 0;
        var right = arr.Length - 1;
        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (arr[mid] < arr[mid + 1])
                left = mid + 1;
            else
                right = mid;
        }

        return left;
    }
}