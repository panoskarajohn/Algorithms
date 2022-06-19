namespace Problems.Google.Arrays;

public class JumpGame
{
    public static bool Execute(int[] nums)
    {
        var canJumpToEnd = new bool[nums.Length];
        var n = nums.Length - 1;
        canJumpToEnd[n] = true;

        for (var i = nums.Length - 1; i >= 0; i--)
            if (canJumpToEnd[i])
            {
            }
            else
            {
                var jump = nums[i];
                if (i + jump > n || canJumpToEnd[i + jump])
                    canJumpToEnd[i] = true;
                else
                    for (var j = i + 1; j < i + jump; j++)
                        if (canJumpToEnd[j])
                        {
                            canJumpToEnd[i] = true;
                            break;
                        }
            }

        return canJumpToEnd[0];
    }
}