using Problems.DataStructures;

namespace Problems.Google.GraphsTrees;

public class MostStonesRemoved
{
    /// <summary>
    /// Key insights
    /// 1. In a connected component, we can always remove all stones except one
    /// 2. Moves in one component do not affect other components
    /// 3. Each stone belongs to exactly one component
    /// </summary>
    /// <param name="stones"></param>
    /// <returns></returns>
    public int FromSameRowOrColumn(int[][] stones)
    {
        var uf = new UnionFind(20005);
        foreach (var stone in stones)
        {
            uf.Union(stone[0], stone[1] + 2354);
        }

        var set = new HashSet<int>();
        foreach (var stone in stones)
        {
            set.Add(uf.Find(stone[0]));
        }
        
        return stones.Length - set.Count;
    }
}