using System.Linq;
using FluentAssertions;

namespace Problem.Tests.Amazon.Graphs;

public class WordSearchTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Word_search_tests(char[][] board, string word, bool expected)
    {
        var result = new WordSearch().Exists(board, word);
        result.Should().Be(expected);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[]
                    {
                        new[] {'A', 'B', 'C', 'E'},
                        new[] {'S', 'F', 'C', 'S'},
                        new[] {'A', 'D', 'E', 'E'}
                    },
                    "ABCCED",
                    true
                },
                new object[]
                {
                    new[]
                    {
                        new[] {'A', 'B', 'C', 'E'},
                        new[] {'S', 'F', 'C', 'S'},
                        new[] {'A', 'D', 'E', 'E'}
                    },
                    "ABCB",
                    false
                },
            };
        }
    }
}

public class WordSearch
{
    class Trie
    {
        public Dictionary<char, Trie> Children { get; set; } = new();
        public string Word { get; set; }
    }
    
    private static readonly int[][] _directions =
    {
        new[] {-1, 0},
        new[] {0, 1},
        new[] {1, 0},
        new[] {0, -1}
    };
    
    private List<(int row, int col)> GetDirections(int row, int col, char[][] board)
    {
        var result = new List<(int row, int col)>();

        foreach (var direction in _directions)
        {
            var newRow = row + direction[0];
            var newCol = col + direction[1];

            if (newRow < 0
                || newRow >= board.Length
                || newCol < 0
                || newCol >= board[newRow].Length)
                continue;

            result.Add((newRow, newCol));
        }

        return result;
    }

    public bool Exists(char[][] board, string word)
    {
        var root = new Trie();
        var node = root;
        foreach (var ch in word)
        {
            if (node.Children.ContainsKey(ch))
                node = node.Children[ch];
            else
            {
                var newNode = new Trie();
                node.Children.Add(ch, newNode);
                node = newNode;
            }
        }

        node.Word = word;
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (Exists(i, j, root, board))
                    return true;
            }
        }
        

        return false;
    }

    private bool Exists(int row, int col, Trie parent, char[][] board)
    {
        var current = board[row][col];
        var currentNode = parent.Children.GetValueOrDefault(current);

        if (currentNode is null)
            return false;

        if (currentNode.Word is not null)
        {
            return true;
        }

        var result = false;
        board[row][col] = '#';

        foreach (var neighbor in GetDirections(row, col, board))
        {
            if (currentNode.Children.ContainsKey(board[neighbor.row][neighbor.col]))
            {
                result = Exists(neighbor.row, 
                    neighbor.col, 
                    currentNode,
                    board);
                
                if (result)
                    break;
            }
        }

        board[row][col] = current;
        return result;
    }
}
