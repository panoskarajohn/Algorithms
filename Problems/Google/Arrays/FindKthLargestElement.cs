namespace Problems.Google.Arrays;

public class FindKthLargestElement
{
    public static int Find(int[] nums, int k)
    {
        var heap = new PriorityQueue<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            heap.Enqueue(nums[i], nums[i]);
            if (heap.Count > k)
                heap.Dequeue();
        }

        return heap.Dequeue();
    }
}