﻿namespace Problems.Array;

public class MinCostToHIreKWorkers
{
    public static double MinCostToHireWorkers(int[] quality, int[] wage, int k)
    {
        var n = quality.Length;

        var workers = new List<(double ratio, int quality)>(n);
        for (var i = 0; i < n; i++)
        {
            var ratio = (double) wage[i] / quality[i];
            workers.Add((ratio, quality[i]));
        }

        var comparer = Comparer<double>.Default;
        workers.Sort((a, b) => comparer.Compare(a.ratio, b.ratio));

        var heap = new PriorityQueue<int, int>();
        var sumHeap = 0;
        var minCost = double.MaxValue;

        foreach (var worker in workers)
        {
            heap.Enqueue(-worker.quality, -worker.quality);
            sumHeap += worker.Item2;

            if (heap.Count > k)
                sumHeap += heap.Dequeue();
            if (heap.Count == k)
                minCost = Math.Min(minCost, sumHeap * worker.ratio);
        }

        return minCost;
    }
}