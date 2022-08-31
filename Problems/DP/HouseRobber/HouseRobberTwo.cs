namespace Problems.DP;

public class HouseRobberTwo
{
    public int Rob(int[] nums)
    {
        var n = nums.Length;

        if (n == 0)
            return 0;

        if (n == 1)
            return nums[0];


        var rob1 = Rob(0, n - 1, in nums);
        var rob2 = Rob(1, n, in nums);

        return Math.Max(rob1, rob2);
    }

    int Rob(int start, int end, in int[] nums)
    {
        var t1 = 0;
        var t2 = 0;

        for (var i = start; i < end; i++)
        {
            var temp = t1;
            var current = nums[i];
            t1 = Math.Max(current + t2, t1);

            t2 = temp;
        }

        return t1;
    }
}