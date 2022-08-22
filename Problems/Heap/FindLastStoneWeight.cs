namespace Problems.Heap;

public class FindLastStoneWeight
{
    public int Get(int[] stones)
    {
        var heap = new PriorityQueue<int, int>();

        foreach (var t in stones) heap.Enqueue(t, -t);

        while (heap.Count > 1)
        {
            var highest = heap.Dequeue();
            var secondHighest = heap.Dequeue();

            if (highest == secondHighest)
                continue;
            var queueItem = highest - secondHighest;
            heap.Enqueue(queueItem, -queueItem);
        }

        return heap.Count > 0 ? heap.Peek() : 0;
    }
}