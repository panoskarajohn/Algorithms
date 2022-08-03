using System.Linq;
using FluentAssertions;

namespace Problem.Tests.Amazon.Graphs;

public class CutOffTreesForGolfEventTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new List<IList<int>> {new List<int> {1, 2, 3}, new List<int> {0, 0, 4}, new List<int> {7, 6, 5}},
                    6
                },
                new object[]
                {
                    new List<IList<int>> {new List<int> {1, 2, 3}, new List<int> {0, 0, 0}, new List<int> {7, 6, 5}},
                    -1
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Cut_off_trees_for_golf_event_tests(IList<IList<int>> forest, int expected)
    {
        var result = new CutOffTreesForGolfEvent().CutOffTree(forest);
        result.Should().Be(expected);
    }
}

/// <summary>
///     Revisit problem is a hard one
/// </summary>
public class CutOffTreesForGolfEvent
{
    private readonly int[][] _directions =
    {
        new[] {1, 0}, // top
        new[] {-1, 0}, //bottom
        new[] {0, 1}, //right
        new[] {0, -1} //left
    };

    public int CutOffTree(IList<IList<int>> forest)
    {
        var visited = new HashSet<(int row, int col)>();
        var queue = new PriorityQueue<(int row, int col), int>();
        visited.Add((0, 0));

        queue.Enqueue((0, 0), forest[0][0]);

        for (var row = 0; row < forest.Count; row++)
        for (var col = 0; col < forest[row].Count; col++)
        {
            var height = forest[row][col];
            if (height > 1)
                queue.Enqueue((row, col), height);
        }

        var answer = 0;
        var currentRow = 0;
        var currentCol = 0;

        while (queue.Count != 0)
        {
            var queueRow = queue.Dequeue();
            var steps = Bfs(currentRow, currentCol, queueRow.row, queueRow.col, forest);
            if (steps == -1)
                return -1;
            answer += steps;
            currentRow = queueRow.row;
            currentCol = queueRow.col;
        }

        return answer;
    }

    private int Bfs(int row, int col, int destRow, int destCol, IList<IList<int>> forest)
    {
        var visited = new HashSet<(int row, int col)>();
        var queue = new Queue<(int row, int col)>();
        var steps = 0;

        queue.Enqueue((row, col));
        visited.Add((row, col));

        while (queue.Any())
        {
            var size = queue.Count;

            for (var i = 0; i < size; i++)
            {
                var current = queue.Dequeue();
                if (current.row == destRow && current.col == destCol)
                    return steps;

                var directions = GetDirections(current.row, current.col, forest);
                foreach (var direction in directions)
                {
                    var isVisited = visited.Contains(direction);
                    var isInvalid = forest[direction.row][direction.col] == 0;
                    if (isVisited || isInvalid)
                        continue;
                    queue.Enqueue(direction);
                    visited.Add(direction);
                }
            }

            steps++;
        }

        return -1;
    }

    private List<(int row, int col)> GetDirections(int row, int col, IList<IList<int>> forest)
    {
        var result = new List<(int row, int col)>();
        foreach (var direction in _directions)
        {
            var neighborRow = row + direction[0];
            var neighborCol = col + direction[1];
            var isOutOfBounds = neighborRow < 0
                                || neighborCol < 0
                                || neighborRow >= forest.Count
                                || neighborCol >= forest[row].Count;

            if (isOutOfBounds)
                continue;
            result.Add((neighborRow, neighborCol));
        }

        return result;
    }
}