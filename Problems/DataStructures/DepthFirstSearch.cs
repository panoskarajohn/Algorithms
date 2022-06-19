namespace Problems.DataStructures;

public class DepthFirstSearch
{
    private readonly Dictionary<int, HashSet<int>> _adjacencyList = new();

    public DepthFirstSearch(int[][] edges)
    {
        CreateAdjacencyList(edges);
    }

    /// <summary>
    ///     Here is an example of the depth-first search algorithm in C# that
    ///     takes an instance of an adjacency list and a starting vertex to find
    ///     all vertices that can be reached by the starting vertex.
    /// </summary>
    /// <param name="start"></param>
    /// <returns></returns>
    public HashSet<int> Dfs(int start)
    {
        var visited = new HashSet<int>();

        if (!_adjacencyList.ContainsKey(start))
            return visited;

        var stack = new Stack<int>();
        stack.Push(start);

        while (stack.Count > 0)
        {
            var vertex = stack.Pop();

            if (visited.Contains(vertex))
                continue;

            visited.Add(vertex);

            foreach (var neighbor in _adjacencyList[vertex])
                if (!visited.Contains(neighbor))
                    stack.Push(neighbor);
        }

        return visited;
    }

    /// <summary>
    ///     Bidirectional adjacency list
    /// </summary>
    /// <param name="edges"></param>
    private void CreateAdjacencyList(int[][] edges)
    {
        foreach (var edge in edges)
        {
            if (_adjacencyList.ContainsKey(edge[0]))
                _adjacencyList[edge[0]].Add(edge[1]);
            else
                _adjacencyList.Add(edge[0], new HashSet<int> {edge[1]});

            if (_adjacencyList.ContainsKey(edge[1]))
                _adjacencyList[edge[1]].Add(edge[0]);
            else
                _adjacencyList.Add(edge[1], new HashSet<int> {edge[0]});
        }
    }
}