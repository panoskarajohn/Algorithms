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
    
    private void Backtrack(int currentNode, LinkedList<int> path)
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
    
    public IList<IList<int>> GetAllPaths2(int[][] graph)
    {
        _graph = graph;
        _target = _graph.Length - 1;
        _results = new List<IList<int>>();
        
        
        LinkedList<int> path = new LinkedList<int>();
        
        var queue = new Queue<LinkedList<int>>();
        path.AddLast(0);
        queue.Enqueue(path);

        while (queue.Any())
        {
            var currentPath = queue.Dequeue();
            int node = currentPath.Last.Value;
            foreach (int neighbor in _graph[node])
            {
                LinkedList<int> tmpPath = new LinkedList<int>(currentPath);
                tmpPath.AddLast(neighbor);
                if (neighbor == _target)
                {
                    _results.Add(new List<int>(tmpPath));
                }
                else
                {
                    queue.Enqueue(new LinkedList<int>(tmpPath));
                }
            }
        }
        return _results;
    }
}