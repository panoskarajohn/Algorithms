namespace Problems.Heap;

public class MinCostToConnectSticks
{
    public int ConnectSticks(int[] sticks) {
        if(sticks.Length < 1)
            return 0;
        
        var pq = new PriorityQueue<int, int>();
        
        foreach(var stick in sticks)
        {
            pq.Enqueue(stick, stick);
        }
        int cost = 0;
        while(pq.Count > 1)
        {
            var first  = pq.Dequeue();
            var second = pq.Dequeue();
            var add = first + second;
            cost += add;
            pq.Enqueue(add, add);
        }
        return cost;
    }
}