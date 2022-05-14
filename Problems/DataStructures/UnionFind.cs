namespace Problems.DataStructures;

/// <summary>
/// Dummy implementation of Union Find
/// </summary>
public class UnionFind {
    private readonly int[] _parents;
    private readonly int[] _size;
    private int _numOfComponents = 0;

    public int NumberOfComponents => _numOfComponents;
    
    /// <summary>
    /// Checks whether two elements belong in the same component
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool IsConnected(int x, int y) => Find(x) == Find(y);

    public UnionFind(int n) 
    {
        _parents = new int[n];
        _size = new int[n];
        _numOfComponents = n;
        for (int i = 0; i < _parents.Length; i++) {
            _parents[i] = i;
            _size[i] = 1;
        }
    }

    private int Find(int cur) 
    {
        int root = cur;
        while (root != _parents[root]) {
            root = _parents[root];
        }
        // Path Compression
        while (cur != root) 
        {
            int preParent = _parents[cur];
            _parents[cur] = root;
            cur = preParent;
        }
        return root;
    }

    public int FindComponentSize(int cur) 
    {
        int parent = Find(cur);
        return _size[parent];
    }

    public bool Union(int node1, int node2) 
    {
        int node1Parent = Find(node1);
        int node2Parent = Find(node2);

        if (node1Parent == node2Parent)
            return false;

        if (_size[node1Parent] > _size[node2Parent]) {
            _parents[node2Parent] = node1Parent;
            _size[node1Parent] += _size[node2Parent];
        } else {
            _parents[node1Parent] = node2Parent;
            _size[node2Parent] += _size[node1Parent];
        }
        _numOfComponents--;

        return true;
    }
}