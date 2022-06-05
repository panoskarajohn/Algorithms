namespace Problems.Google.GraphsTrees;

public class AllPathsFromSourceToTarget
{
    private int _target;
    /// <summary>
    /// This is already an adjacency list. Every index is already a node.
    /// </summary>
    private int[][] _graph;
    private List<IList<int>> _results;

    public IList<IList<int>> GetAllPaths(int[][] graph)
    {
        _graph = graph;
        _target = _graph.Length - 1;
        _results = new List<IList<int>>();
        //Adopt the LinkedList for fast access to the tail element
        LinkedList<int> path = new LinkedList<int>();
        path.AddLast(0);
        Backtrack(0, path);
        return _results;
    }
    
    public void Backtrack(int currentNode, LinkedList<int> path)
    {
        if (currentNode == _target)
        {
            _results.Add(new List<int>(path));
            return;
        }

        foreach (var neighbor in _graph[currentNode])
        {
            path.AddLast(neighbor);
            Backtrack(neighbor, path);
            path.RemoveLast();
        }
    }
}