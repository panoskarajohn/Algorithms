using System.Runtime.InteropServices.ComTypes;

namespace Problems.Amazon.Graphs;

public class CriticalConnections
{
    private Dictionary<int, HashSet<int>> _graph;
    private Dictionary<int, int> _rank;
    private Dictionary<(int from, int to), bool> _connectionDictionary;

    public CriticalConnections()
    {
        this._graph = new Dictionary<int, HashSet<int>>();
        this._rank = new Dictionary<int, int>();
        this._connectionDictionary = new Dictionary<(int from, int to), bool>();
    }
    public IList<IList<int>> Get(int n, IList<IList<int>> connections)
    {
        var result = new List<IList<int>>();
        BuildGraph(n, connections);
        Dfs(0, 0);

        foreach (var conn in _connectionDictionary.Keys) 
        {
            result.Add(new List<int>() { conn.from, conn.to });
        }

        return result;
        
    }

    private int Dfs(int node, int discoveryRank)
    {
        //that means this node is already visit. We simply return the rank
        if (this._rank[node] != -1)
        {
            return _rank[node];
        }
        
        //update the rank of this node
        _rank[node] = discoveryRank;
        
        //This is the max we have seen till now. So we start with this instead of INT_MAX or something
        int minRank = discoveryRank + 1;

        foreach (var neighbor in _graph[node])
        {
            int neighborRank = _rank[neighbor];
            // not visited and is not previous rank
            if(neighborRank != -1 && neighborRank == discoveryRank - 1)
                 continue;
            
            //Recurse the neighbor
            int recursiveRank = Dfs(neighbor, discoveryRank + 1);

            //Check if this edge needs to be discarded
            if (recursiveRank <= discoveryRank)
            {
                int u = Math.Min(node, neighbor);
                int v = Math.Max(node, neighbor);

                _connectionDictionary.Remove((u, v));
            }

            minRank = Math.Min(minRank, recursiveRank);
        }

        return minRank;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="n"></param>
    /// <param name="connections"></param>
    private void BuildGraph(int n, IList<IList<int>> connections)
    {
        for (int i = 0; i < n; i++)
        {
            _graph.Add(i, new HashSet<int>());
            _rank.Add(i, -1);
        }

        foreach (var connection in connections)
        {
            int u = connection[0];
            int v = connection[1];

            _graph[u].Add(v);
            _graph[v].Add(u);
            int start = Math.Min(u, v);
            int end = Math.Max(u, v);
            
            _connectionDictionary.TryAdd((start, end), true);
        }
    }
    
    
    
}