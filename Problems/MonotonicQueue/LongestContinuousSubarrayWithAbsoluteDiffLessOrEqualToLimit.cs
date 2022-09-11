using Problems.DataStructures;

namespace Problems.MonotonicQueue;

public class LongestContinuousSubarrayWithAbsoluteDiffLessOrEqualToLimit
{
    public int LongestSubarray(int[] nums, int limit)
    {
        // C# does not contain a class for Deque(double ended queue)
        // We need to mock it
        var minQueue = new LinkedList<int>();
        var maxQueue = new LinkedList<int>();

        int n = nums.Length;
        int left = 0;
        int right = 0;
        int best = int.MinValue;

        while (right < n)
        {
            while(maxQueue.Any() && maxQueue!.Last!.Value < nums[right])
                maxQueue.RemoveLast();

            maxQueue.AddLast(nums[right]);
            
            while(minQueue.Any() && minQueue!.Last!.Value > nums[right])
                minQueue.RemoveLast();

            minQueue.AddLast(nums[right]);

            while (maxQueue!.First!.Value - minQueue!.First!.Value > limit)
            {
                if(maxQueue.First.Value == nums[left]) maxQueue.RemoveFirst();
                if(minQueue.First.Value == nums[left]) minQueue.RemoveFirst();

                left++;
            }

            best = Math.Max(best, right - left + 1);
            right++;
        }

        return best;

    }
}