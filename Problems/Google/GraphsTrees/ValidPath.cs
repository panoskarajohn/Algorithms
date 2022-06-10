using Problems.DataStructures;

namespace Problems.Google.GraphsTrees;

public class ValidatePath
{
    /// <summary>
    /// Union find solution
    /// </summary>
    /// <param name="n"></param>
    /// <param name="edges"></param>
    /// <param name="source"></param>
    /// <param name="destination"></param>
    /// <returns></returns>
    public bool IsValidPathUnionFind(int n, int[][] edges, int source, int destination)
    {
        if (source == destination) return true;
        var unionFind = new UnionFind(n);

        foreach (var edge in edges)
        {
            unionFind.Union(edge[0], edge[1]);
        }
        
        return unionFind.Find(source) == unionFind.Find(destination);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="n"></param>
    /// <param name="edges"></param>
    /// <param name="source"></param>
    /// <param name="destination"></param>
    /// <returns></returns>
    public bool IsValidPathDfs(int n, int[][] edges, int source, int destination)
    {
        if (source == destination) return true;
        var dfs = new DepthFirstSearch(edges);
        return dfs.Dfs(source).Contains(destination);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="n"></param>
    /// <param name="edges"></param>
    /// <param name="source"></param>
    /// <param name="destination"></param>
    /// <returns></returns>
    public bool IsValidPathBfs(int n, int[][] edges, int source, int destination)
    {
        if (source == destination) return true;
        var bfs = new BreadthFirstSearch(edges);
        return bfs.Bfs(source).Contains(destination);
    }
}