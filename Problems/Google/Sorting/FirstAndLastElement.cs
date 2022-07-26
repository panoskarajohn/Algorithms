namespace Problems.Google.Sorting;

public class FirstAndLastElement
{
    public int[] Find(int[] nums, int target)
    {
        int first = BinarySearch(nums, target, false);

        if (first == -1)
            return new[] {-1, -1};

        int second = BinarySearch(nums, target, true);
        return new int[] {first, second};
    }

    int BinarySearch(int[] nums, int target, bool isOccured)
    {
        int n = nums.Length;
        int begin = 0;
        int end = n - 1;

        while (begin <= end)
        {
            int mid = (begin + end) / 2;
            if (nums[mid] == target)
            {
                if (!isOccured)
                {
                    if (mid == begin || nums[mid -1] != target)
                        return mid;
                    end = mid - 1;
                }
                else
                {
                    if (mid == end || nums[mid + 1] != target)
                    {
                        return mid;
                    }

                    begin = mid + 1;
                }
            }
            else if(nums[mid] > target)
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