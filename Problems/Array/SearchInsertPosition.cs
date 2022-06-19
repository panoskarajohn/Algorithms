namespace Problems.Array;

public class SearchInsertPosition
{
    public static int Execute(int[] nums, int target)
    {
        if (nums.Length == 1 && nums[0] >= target) return 0;
        if (nums.Length == 1 && nums[0] < target) return 1;
        return BinarySearch(nums, 0, nums.Length - 1, target);
    }


    /// <summary>
    ///     A custom made Binary search which returns the index between
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    private static int BinarySearch(int[] nums, int start, int end, int target)
    {
        if (start > end) return 0;

        var mid = (end + start) / 2;

        if (nums[mid] == target)
            return mid;

        if (mid + 1 < nums.Length && nums[mid] < target && nums[mid + 1] > target)
            return mid + 1;

        if (mid == nums.Length - 1)
            return nums.Length;

        if (nums[mid] > target) return BinarySearch(nums, start, mid - 1, target);

        return BinarySearch(nums, mid + 1, end, target);
    }
}