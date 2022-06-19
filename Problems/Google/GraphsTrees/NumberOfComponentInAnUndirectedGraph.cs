using Problems.DataStructures;

namespace Problems.Google.GraphsTrees;

public class NumberOfComponentInAnUndirectedGraph
{
    public static int CountComponents(int n, int[][] edges)
    {
        var uf = new UnionFind(n);
        foreach (var edge in edges) uf.Union(edge[0], edge[1]);
        return uf.Count;
    }
}