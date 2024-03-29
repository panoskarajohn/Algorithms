﻿namespace Problems.Google.GraphsTrees;

public class NetworkDelay
{
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        var adjList = new List<(int node, int weight)>[n + 1];

        for (var i = 0; i <= n; i++) adjList[i] = new List<(int node, int weight)>();

        foreach (var time in times) adjList[time[0]].Add((time[1], time[2]));

        var visited = new bool[n + 1];

        var pq = new PriorityQueue<int, int>();

        pq.Enqueue(k, 0);
        var result = 0;
        var visitedCount = 0;
        while (pq.TryDequeue(out var node, out var weight))
        {
            if (visited[node]) continue;
            visitedCount++;
            visited[node] = true;
            result = Math.Max(result, weight);
            foreach (var adj in adjList[node])
            {
                var totalWeight = weight + adj.weight;
                pq.Enqueue(adj.node, totalWeight);
            }
        }

        return visitedCount == n ? result : -1;
    }
}