namespace Problems.Google.Sorting;

public class FirstAndLastElement
{
    public int[] Find(int[] nums, int target)
    {
        var first = BinarySearch(nums, target, false);

        if (first == -1)
            return new[] {-1, -1};

        var second = BinarySearch(nums, target, true);
        return new[] {first, second};
    }

    private int BinarySearch(int[] nums, int target, bool isOccured)
    {
        var n = nums.Length;
        var begin = 0;
        var end = n - 1;

        while (begin <= end)
        {
            var mid = (begin + end) / 2;
            if (nums[mid] == target)
            {
                if (!isOccured)
                {
                    if (mid == begin || nums[mid - 1] != target)
                        return mid;
                    end = mid - 1;
                }
                else
                {
                    if (mid == end || nums[mid + 1] != target) return mid;

                    begin = mid + 1;
                }
            }
            else if (nums[mid] > target)
            {
                end = mid - 1;
            }
            else
            {
                begin = mid + 1;
            }
        }

        return -1;
    }
}