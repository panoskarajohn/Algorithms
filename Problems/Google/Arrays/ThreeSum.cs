namespace Problems.Google.Arrays;

public static class ThreeSum
{
    public static IList<IList<int>> Execute(int[] nums)
    {
        IList<IList<int>> triplets = new List<IList<int>>();
        if (nums.Length < 3) // no triplet can be made
            return triplets;

        System.Array.Sort(nums);

        for (var i = 0; i + 2 < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;
            var j = i + 1;
            var k = nums.Length - 1;
            while (j < k)
            {
                var sum = nums[i] + nums[j] + nums[k];
                if (sum == 0)
                {
                    triplets.Add(new List<int> {nums[i], nums[j], nums[k]});
                    k--;
                    while (j < k && nums[k] == nums[k + 1]) k--;
                }
                else if (sum > 0)
                {
                    k--;
                }
                else
                {
                    j++;
                }
            }

            j = 0;
            k = nums.Length - 1;
        }

        return triplets;
    }
}