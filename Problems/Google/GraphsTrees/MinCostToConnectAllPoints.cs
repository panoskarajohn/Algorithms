using System;
using System.Collections.Generic;
using Problems.DataStructures;

namespace Problems.Google.GraphsTrees;

public class MinCostToConnectAllPoints
{
    public int MinCost(int[][] points)
    {
        var n = points.Length;
        var edges = new List<(int weight, int current, int next)>();

        for (var i = 0; i < n; i++)
        for (var j = i + 1; j < n; j++)
        {
            var weight = GetManhattanDistance(points[i][0], points[j][0], points[i][1], points[j][1]);
            edges.Add((weight, i, j));
        }

        var comparer = Comparer<(int weight, int current, int next)>.Default;
        edges.Sort((x, y) => x.weight.CompareTo(y.weight));

        var uf = new UnionFind(n);
        var cost = 0;

        foreach (var edge in edges)
            if (uf.Union(edge.current, edge.next))
                cost += edge.weight;
        return cost;
    }

    private int GetManhattanDistance(int x1, int x2, int y1, int y2)
    {
        return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
    }
}