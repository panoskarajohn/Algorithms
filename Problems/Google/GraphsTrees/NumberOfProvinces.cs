using Problems.DataStructures;

namespace Problems.Google.GraphsTrees;

public class NumberOfProvinces
{
    public static int FindCircleNum(int[][] isConnected)
    {
        int n = isConnected.Length;
        var uf = new UnionFind(n);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (isConnected[i][j] == 1)
                {
                    uf.Union(i, j);
                }
            }
        }
        
        return uf.NumberOfComponents;
    }
}