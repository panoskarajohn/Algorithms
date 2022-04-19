namespace Problem.Tests.Array;

public static class RemoveElement
{
    
    public static int Execute(int[] nums, int val)
    {
        int n = nums.Length;
        int j = 0;
        for (int i = 0; i < n; i++)
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