using Problems.DataStructures;

namespace Problems.Google.GraphsTrees;

public static class TheEarliestTimeThatEveryoneBecomeFriends
{
    public static int EarliestAcq(int[][] logs, int n)
    {
        if (logs is null || logs.Length == 0)
            return -1;
        
        // Sort the logs by timestamp
        var comparer = Comparer<int>.Default;
        System.Array.Sort(logs, (a, b) => comparer.Compare(a[0], b[0]));

        var uf = new UnionFind(n);
        int group = n;

        foreach (var log in logs)
        {
            if (uf.Union(log[1], log[2]))
                group--;

            if (group == 1)
                return log[0];
        }
        
        return -1;
    }
    
}