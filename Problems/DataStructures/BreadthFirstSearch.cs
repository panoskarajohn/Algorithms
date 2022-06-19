namespace Problems.DataStructures;

public class BreadthFirstSearch
{
    private readonly Dictionary<int, HashSet<int>> _adjacencyList = new();

    public BreadthFirstSearch(int[][] edges)
    {
        CreateAdjacencyList(edges);
    }

    public HashSet<int> Bfs(int start)
    {
        var visited = new HashSet<int>();

        var queue = new Queue<int>();
        queue.Enqueue(start);

        while (queue.Any())
        {
            var vertex = queue.Dequeue();

            if (visited.Contains(vertex))
                continue;

            visited.Add(vertex);

            foreach (var neighbor in _adjacencyList[vertex])
                if (!visited.Contains(neighbor))
                    queue.Enqueue(neighbor);
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