using Problems.DataStructures;

namespace Problems.Amazon.Arrays;

public class MissingNumbers
{
    public int Find(int[] nums)
    {
        int sum = 0;
        for (int i = 1; i < nums.Length + 1; i++)
            sum += i;

        var currentSum = nums.Sum();

        return sum - currentSum;

    }
}