namespace Problems.DataStructures;

/// <summary>
/// Dummy implementation of Union Find
/// </summary>
public class UnionFind
{
    private readonly int[] _parents;
    private readonly int[] _size;
    private int _numOfComponents = 0;

    public int NumberOfComponents => _numOfComponents;

    /// <summary>
    /// Checks whether two elements belong in the same component
    /// </summary>
    /// <param name="node1"></param>
    /// <param name="node2"></param>
    /// <returns></returns>
    public bool IsConnected(int node1, int node2) => Find(node1) == Find(node2);

    public UnionFind(int n)
    {
        _parents = new int[n];
        _size = new int[n];
        _numOfComponents = n;
        for (int i = 0; i < _parents.Length; i++)
        {
            _parents[i] = i;
            _size[i] = 1;
        }
    }

    private int Find(int cur)
    {
        int root = cur;
        while (root != _parents[root])
        {
            root = _parents[root];
        }

        // Path Compression
        while (cur != root)
        {
            (_parents[cur], cur) = (cur, _parents[cur]);
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

        if (_size[node1Parent] > _size[node2Parent])
        {
            _parents[node2Parent] = node1Parent;
            _size[node1Parent] += _size[node2Parent];
        }
        else
        {
            _parents[node1Parent] = node2Parent;
            _size[node2Parent] += _size[node1Parent];
        }

        _numOfComponents--;

        return true;
    }
}

public class UnionFindLeet {
    private int[] _group;
    private int[] _rank;
    private int _count;
    public int Count => _count;

    public UnionFindLeet(int size) {
        this._group = new int[size];
        this._rank = new int[size];
        _count = size;
        for (int person = 0; person < size; ++person) {
            this._group[person] = person;
            this._rank[person] = 0;
        }
    }
        
    public int Find(int person) {
        if (this._group[person] != person)
            this._group[person] = this.Find(this._group[person]);
        return this._group[person];
    }
        
    public bool Union(int a, int b) {
        int groupA = this.Find(a);
        int groupB = this.Find(b);
        bool isMerged = false;

        // The two people share the same group.
        if (groupA == groupB)
            return isMerged;

        // Otherwise, merge the two groups.
        isMerged = true;
        // Merge the lower-rank group into the higher-rank group.
        if (this._rank[groupA] > this._rank[groupB]) {
            this._group[groupB] = groupA;
        } else if (this._rank[groupA] < this._rank[groupB]) {
            this._group[groupA] = groupB;
        } else {
            this._group[groupA] = groupB;
            this._rank[groupB] += 1;
        }

        _count--;

        return isMerged;
    }
}