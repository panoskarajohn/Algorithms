using Problems.DataStructures;

namespace Problems.Google.GraphsTrees;

public static class OptimizeWaterDistribution
{
    /// <summary>
    /// </summary>
    /// <param name="n">Number of houses</param>
    /// <param name="wells">Cost for ith house well</param>
    /// <param name="pipes">house1 [0], house2[1], cost[2]</param>
    /// <returns></returns>
    public static int MinCostToSupplyWater(int n, int[] wells, int[][] pipes)
    {
        var uf = new UnionFind(n + wells.Length);
        var edges = new List<(int cost, int u, int v)>();

        // Create virtual nodes
        for (var i = 0; i < wells.Length; i++) edges.Add((wells[i], 0, i + 1));

        foreach (var pipe in pipes) edges.Add((pipe[2], pipe[0], pipe[1]));

        var comparer = Comparer<(int cost, int u, int v)>.Default;
        edges.Sort((x, y) => x.cost.CompareTo(y.cost));

        var cost = 0;
        //build dummy edge from each house to the dummy well
        foreach (var edge in edges)
            if (uf.Union(edge.u, edge.v))
                cost += edge.cost;
        return cost;
    }
}