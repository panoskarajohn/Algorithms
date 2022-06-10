namespace Problems.Google.GraphsTrees;

public class AllPathsFromSourceLeadToDestination
{
    private Dictionary<int, HashSet<int>> _graph = new Dictionary<int, HashSet<int>>();

    private int _target;
    
    public bool AllLeadsToDestination(int n, int[][] edges, int source, int destination)
    {
        _target = destination;
        foreach (var edge in edges)
        {
            if (!_graph.ContainsKey(edge[0]))
                _graph[edge[0]] = new HashSet<int>();
            _graph[edge[0]].Add(edge[1]);
        }
        
        if (_graph.ContainsKey(destination) && _graph[destination].Count > 0)
            return false;

        var visited = new HashSet<int> {source};
        return Backtrack(source, visited);    
    }

    private bool Backtrack(int currentNode, HashSet<int> visited)
    {
        if (!_graph.ContainsKey(currentNode))
            return currentNode == _target;

        foreach (var neighbor in _graph[currentNode])
        {
            if (visited.Contains(neighbor))
                return false;

            visited.Add(neighbor);
            if (!Backtrack(neighbor, visited))
                return false;
            visited.Remove(neighbor);
        }

        return true;
    }
}