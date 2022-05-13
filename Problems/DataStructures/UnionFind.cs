﻿namespace Problems.DataStructures;

/// <summary>
/// Dummy implementation of Union Find
/// </summary>
public class UnionFind {
    private int[] _parents;
    private int[] _size;
    private int _numOfComponets = 0;

    public int NumberOfComponents => _numOfComponets;

    public UnionFind(int n) {
        _parents = new int[n];
        _size = new int[n];
        _numOfComponets = n;
        for (int i = 0; i < _parents.Length; i++) {
            _parents[i] = i;
            _size[i] = 1;
        }
    }

    public int Find(int cur) {
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

    public int FindComponentSize(int cur) {
        int parent = Find(cur);
        return _size[parent];
    }

    public void Union(int node1, int node2) {
        int node1Parent = Find(node1);
        int node2Parent = Find(node2);

        if (node1Parent == node2Parent)
            return;

        if (_size[node1Parent] > _size[node2Parent]) {
            _parents[node2Parent] = node1Parent;
            _size[node1Parent] += _size[node2Parent];
        } else {
            _parents[node1Parent] = node2Parent;
            _size[node2Parent] += _size[node1Parent];
        }
        _numOfComponets--;
    }
}