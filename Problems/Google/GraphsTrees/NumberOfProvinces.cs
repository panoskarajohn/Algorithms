using Problems.DataStructures;

namespace Problems.Google.GraphsTrees;

public class NumberOfProvinces
{
    public static int FindCircleNum(int[][] isConnected)
    {
        var n = isConnected.Length;
        var uf = new UnionFind(n);

        for (var i = 0; i < n; i++)
        for (var j = 0; j < n; j++)
            if (isConnected[i][j] == 1)
                uf.Union(i, j);

        return uf.Count;
    }
}