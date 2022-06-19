namespace Problems.Google.Arrays;

public static class NextPermutation
{
    public static void SetNext(int[] nums)
    {
        var n = nums.Length;
        var swapFound = false;
        for (var i = n - 1; i > 0; i--)
        {
            var current = nums[i];
            var prev = nums[i - 1];
            if (current > prev)
            {
                swapFound = true;
                var numberToSwap = prev;
                var indexToSwapWith = -1;
                for (var j = i + 1; j < nums.Length; j++)
                    if (numberToSwap >= nums[j])
                    {
                        indexToSwapWith = j - 1;
                        break;
                    }

                if (indexToSwapWith == -1)
                    indexToSwapWith = n - 1; //Last Element

                (nums[i - 1], nums[indexToSwapWith]) = (nums[indexToSwapWith], nums[i - 1]);

                Reverse(nums, i);
                break;
            }
        }

        if (!swapFound) Reverse(nums, 0);
    }

    private static void Reverse(int[] nums, int start)
    {
        int i = start, j = nums.Length - 1;
        while (i < j)
        {
            (nums[i], nums[j]) = (nums[j], nums[i]);
            i++;
            j--;
        }
    }
}