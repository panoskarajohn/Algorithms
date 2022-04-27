namespace Problems.Google.Arrays;

public class JumpGame
{
    public static bool Execute(int[] nums)
    {
        var canJumpToEnd = new bool[nums.Length];
        int n = nums.Length - 1;
        canJumpToEnd[n] = true;
        
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (canJumpToEnd[i])
                continue;
            else
            {
                int jump = nums[i];
                if (i + jump > n || canJumpToEnd[i + jump])
                {
                    canJumpToEnd[i] = true;
                }
                else
                {
                    for (int j = i + 1; j < i + jump; j++)
                    {
                        if (canJumpToEnd[j])
                            canJumpToEnd[i] = true;
                    }
                }
            }
        }

        return canJumpToEnd[0];
    }
}