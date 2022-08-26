using FluentAssertions;

namespace KickStarter.SessionThree;

public class WiggleWalk
{
    private int _cols;

    Dictionary<char, int[]> _directionMap = new()
    {
        {'N', new[] {-1, 0}},
        {'E', new[] {0, 1}},
        {'W', new[] {0, -1}},
        {'S', new[] {1, 0}}
    };

    private int _rows;

    public int[] GetLastPositionAfterInstructions(
        int numberOfInstructions,
        int rows,
        int columns,
        int startingRow,
        int startingColumn,
        string instructions)
    {
        _rows = rows;
        _cols = columns;

        var (row, col) = (startingRow, startingColumn);
        var visited = new HashSet<(int, int)>();
        var cache = new Dictionary<(char, int, int), (int, int)>();

        for (var i = 0; i < numberOfInstructions; i++) (row, col) = Move(instructions[i], row, col, visited, cache);

        return new[] {row, col};
    }

    private (int row, int col) Move(char instruction, int currentRow, int currentCol,
        HashSet<(int row, int col)> visited, Dictionary<(char, int, int), (int, int)> cache)
    {
        visited.Add((currentRow, currentCol));
        (int row, int col) destination;
        if (cache.ContainsKey((instruction, currentRow, currentCol)))
            destination = cache[(instruction, currentRow, currentCol)];
        else
        {
            destination =  GetDestination(instruction, currentRow, currentCol); 
        }
        
        while (visited.Contains(destination))
        {
            var temp = GetDestination(instruction, destination.row, destination.col);
            if (temp.row < 0 || temp.row > _rows || temp.col < 0 || temp.col > _cols)
            {
                visited.Add(destination);
                cache[(instruction, currentRow, currentCol)] = destination;
                return destination;
            }

            destination = temp;
        }

        visited.Add(destination);
        return cache[(instruction, currentRow, currentCol)] = destination;
    }

    private (int row, int col) GetDestination(char instruction, int currentRow, int currentCol)
    {
        var direction = _directionMap[instruction];
        return (currentRow + direction[0], currentCol + direction[1]);
    }
}

public class WiggleWalkTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    5, 3, 6, 2, 3,
                    "EEWNS",
                    3, 2
                },
                new object[]
                {
                    4, 3, 3, 1, 1,
                    "SESE",
                    3, 3
                },
                new object[]
                {
                    11, 5, 8, 3, 4,
                    "NEESSWWNESE",
                    3, 7
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Wiggle_walk_tests(int numberOfInstructions, int rows, int columns, int startingRow, int startingColumn,
        string instrustions, int expectedRow, int expectedColumn)
    {
        var result = new WiggleWalk().GetLastPositionAfterInstructions(numberOfInstructions, rows, columns, startingRow,
            startingColumn, instrustions);
        result[0].Should().Be(expectedRow);
        result[1].Should().Be(expectedColumn);
    }
}