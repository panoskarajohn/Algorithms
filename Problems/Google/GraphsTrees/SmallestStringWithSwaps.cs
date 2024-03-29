﻿using Problems.DataStructures;

namespace Problems.Google.GraphsTrees;

public static class SmallestStringWithSwaps
{
    public static string Get(string s, IList<IList<int>> pairs)
    {
        var dictionary = new Dictionary<int, PriorityQueue<char, char>>();

        var uf = new UnionFind(s.Length);

        foreach (var pair in pairs) uf.Union(pair[0], pair[1]);

        for (var i = 0; i < s.Length; i++)
        {
            var parentId = uf.Find(i);
            if (dictionary.ContainsKey(parentId))
            {
                dictionary[parentId].Enqueue(s[i], s[i]);
            }
            else
            {
                var pq = new PriorityQueue<char, char>();
                pq.Enqueue(s[i], s[i]);
                dictionary.Add(parentId, pq);
            }
        }

        Span<char> charArray = stackalloc char[s.Length];

        for (var i = 0; i < s.Length; i++)
        {
            var parentId = uf.Find(i);
            charArray[i] = dictionary[parentId].Dequeue();
        }

        return new string(charArray);
    }
}