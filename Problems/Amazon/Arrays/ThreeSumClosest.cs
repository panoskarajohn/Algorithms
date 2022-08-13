namespace Problems.Amazon.Arrays;

public class ThreeSumClosest
{
    public int Closest(int[] nums, int target)
    {
        var diff = int.MaxValue;

        if (nums.Length < 3)
            return 0;

        System.Array.Sort(nums);

        for (var i = 0; i < nums.Length; i++)
        {
            if (diff == 0)
                break;

            var current = nums[i];
            var left = i + 1;
            var right = nums.Length - 1;

            while (left < right)
            {
                var sum = current + nums[left] + nums[right];
                if (Math.Abs(target - sum) < Math.Abs(diff))
                    diff = target - sum;

                if (sum < target)
                    left++;
                else
                    right--;
            }
        }

        return target - diff;
    }
}