using Problems.DataStructures;

namespace Problems.Google.GraphsTrees;

public static class ValidTree
{
    public static bool IsValid(int n, int[][] edges)
    {
        var uf = new UnionFind(n);

        foreach (var edge in edges)
            if (!uf.Union(edge[0], edge[1]))
                return false;

        return uf.Count == 1;
    }
}