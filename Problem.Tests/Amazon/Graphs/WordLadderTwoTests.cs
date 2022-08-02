using System.Linq;
using FluentAssertions;

namespace Problem.Tests.Amazon.Graphs;

public class WordLadderTwoTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "hit",
                    "cog",
                    new List<string> {"hot", "dot", "dog", "lot", "log", "cog"},
                    new List<IList<string>>
                    {
                        new List<string> {"hit", "hot", "dot", "dog", "cog"},
                        new List<string> {"hit", "hot", "lot", "log", "cog"}
                    }
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Word_ladder_two_tests(string beginWord, string endWord, List<string> wordList,
        IList<IList<string>> expected)
    {
        var result = new WordLadderTwo().FindLadders(beginWord, endWord, wordList);
        result.Should().BeEquivalentTo(expected);
    }
}

/// <summary>
///     BFS & DFS solution this gets time limit exceeded
/// </summary>
public class WordLadderTwo
{
    private readonly Dictionary<string, List<string>> _adjacencyList = new();
    private readonly LinkedList<string> _path = new();
    private readonly IList<IList<string>> _shortestPaths = new List<IList<string>>();

    public IList<IList<string>> FindLadders(string beginWord, string endWord, List<string> wordList)
    {
        var copied = new HashSet<string>(wordList);
        Bfs(beginWord, endWord, copied);
        _path.AddLast(beginWord);
        Backtrack(beginWord, endWord);

        return _shortestPaths;
    }

    private List<string> FindNeighbors(string word, HashSet<string> wordList)
    {
        var neighbors = new List<string>();
        var charArray = word.ToCharArray();

        for (var i = 0; i < word.Length; i++)
        {
            var oldChar = charArray[i];
            for (var c = 'a'; c <= 'z'; c++)
            {
                charArray[i] = c;

                if (c == oldChar || !wordList.Contains(new string(charArray)))
                    continue;
                neighbors.Add(new string(charArray));
            }

            charArray[i] = oldChar;
        }

        return neighbors;
    }

    private void Bfs(string begin, string end, HashSet<string> wordList)
    {
        var queue = new Queue<string>();
        queue.Enqueue(begin);

        if (wordList.Contains(begin))
            wordList.Remove(begin);

        var isEnqueued = new HashSet<string>();
        isEnqueued.Add(begin);

        while (queue.Any())
        {
            var visited = new HashSet<string>();
            var size = queue.Count;
            for (var i = 0; i < size; i++)
            {
                var current = queue.Dequeue();
                var neighbors = FindNeighbors(current, wordList);

                foreach (var neighbor in neighbors)
                {
                    visited.Add(neighbor);
                    if (!_adjacencyList.ContainsKey(current))
                        _adjacencyList.Add(current, new List<string>());

                    _adjacencyList[current].Add(neighbor);
                    if (!isEnqueued.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        isEnqueued.Add(neighbor);
                    }
                }
            }

            foreach (var v in visited)
                if (wordList.Contains(v))
                    wordList.Remove(v);
        }
    }

    private void Backtrack(string source, string destination)
    {
        if (source == destination) _shortestPaths.Add(_path.ToList());

        if (!_adjacencyList.ContainsKey(source)) return;

        foreach (var neighbor in _adjacencyList[source])
        {
            _path.AddLast(neighbor);
            Backtrack(neighbor, destination);
            _path.RemoveLast();
        }
    }
}