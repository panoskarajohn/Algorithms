namespace Problems.Amazon.Arrays;

public class MissingNumbers
{
    public int Find(int[] nums)
    {
        var sum = 0;
        for (var i = 1; i < nums.Length + 1; i++)
            sum += i;

        var currentSum = nums.Sum();

        return sum - currentSum;
    }
}