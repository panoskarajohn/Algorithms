namespace Problems.Array;

public static class RemoveElement
{
    public static int Execute(int[] nums, int val)
    {
        var n = nums.Length;
        var j = 0;
        for (var i = 0; i < n; i++)
        {
            var current = nums[i];

            if (current == val)
                continue;

            nums[i] = nums[j];
            j++;
        }

        return j;
    }
}