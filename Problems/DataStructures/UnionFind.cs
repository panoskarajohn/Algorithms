﻿namespace Problems.DataStructures;

/// <summary>
/// </summary>
public class UnionFind
{
    private readonly int[] _group;
    private readonly int[] _rank;

    public UnionFind(int size)
    {
        _group = new int[size];
        _rank = new int[size];
        Count = size;
        for (var person = 0; person < size; ++person)
        {
            _group[person] = person;
            _rank[person] = 0;
        }
    }

    public int Count { get; private set; }

    public int Find(int person)
    {
        if (_group[person] != person)
            _group[person] = Find(_group[person]);
        return _group[person];
    }

    public bool Union(int a, int b)
    {
        var groupA = Find(a);
        var groupB = Find(b);

        // The two people share the same group.
        if (groupA == groupB)
            return false;

        // Otherwise, merge the two groups.
        // Merge the lower-rank group into the higher-rank group.
        if (_rank[groupA] > _rank[groupB])
        {
            _group[groupB] = groupA;
        }
        else if (_rank[groupA] < _rank[groupB])
        {
            _group[groupA] = groupB;
        }
        else
        {
            _group[groupA] = groupB;
            _rank[groupB] += 1;
        }

        Count--;

        return true;
    }
}