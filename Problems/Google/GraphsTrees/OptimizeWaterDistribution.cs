using System.Collections;
using Problems.DataStructures;

namespace Problems.Google.GraphsTrees;

public static class OptimizeWaterDistribution
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="n">Number of houses</param>
    /// <param name="wells">Cost for ith house well</param>
    /// <param name="pipes">house1 [0], house2[1], cost[2]</param>
    /// <returns></returns>
    public static int MinCostToSupplyWater(int n, int[] wells, int[][] pipes)
    {
        var uf = new UnionFindLeet(n + wells.Length);
        var edges = new List<(int cost, int u, int v)>();

        // Create virtual nodes
        for (int i = 0; i < wells.Length; i++)
        {
            edges.Add((wells[i], 0, i + 1));
        }

        foreach (var pipe in pipes)
        {
            edges.Add((pipe[2], pipe[0], pipe[1]));
        }
        
        Comparer<(int cost,int u,int v)> comparer = Comparer<(int cost, int u, int v)>.Default;
        edges.Sort((x,y) => x.cost.CompareTo(y.cost));
        
        int cost = 0;
        //build dummy edge from each house to the dummy well
        foreach (var edge in edges)
        {
            if (uf.Union(edge.u, edge.v))
            {
                cost += edge.cost;
            }
        }
        return cost;
    }
}