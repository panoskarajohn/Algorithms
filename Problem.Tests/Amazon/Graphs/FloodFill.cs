using System.Linq;
using FluentAssertions;
using Problem.Tests.Google.Arrays;

namespace Problem.Tests.Amazon.Graphs;

public class FloodFillTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Flood_fill_tests(int[][] image, int sr, int sc, int color, int[][] expectedImage)
    {
        var result = new FloodFill().Do(image, sr, sc, color);
        result.Should().BeEquivalentTo(expectedImage);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {new[] {1, 1, 1}, new[] {1, 1, 0}, new[] {1,0,1}},
                    1,
                    1,
                    2,
                    new[] {new[] {2, 2, 2}, new[] {2, 2, 0}, new[] {2,0,1}},
                }
            };
        }
    }
}


public class FloodFill
{
    private readonly int[][] _directions =
    {
        new[] {1, 0}, // top
        new[] {-1, 0}, //bottom
        new[] {0, 1}, //right
        new[] {0, -1} //left
    };
    public int[][] Do(int[][] image, int sr, int sc, int color)
    {
        var startingColor = image[sr][sc];
        var queue = new Queue<(int row, int col)>();
        var visited = new HashSet<(int row, int col)>();
        queue.Enqueue((sr, sc));
        visited.Add((sr, sc));
        image[sr][sc] = color;

        while (queue.Any())
        {
            var current = queue.Dequeue();
            
            foreach (var neighbor in GetDirections(current.row, current.col, startingColor, image, visited))
            {
                queue.Enqueue(neighbor);
                visited.Add(neighbor);
                image[neighbor.row][neighbor.col] = color;
            }
        }

        return image;
    }
    
    private List<(int row, int col)> GetDirections(int row, int col, int color , int[][] image, HashSet<(int row, int col)> visited)
    {
        var result = new List<(int row, int col)>();
        foreach (var direction in _directions)
        {
            var neighborRow = row + direction[0];
            var neighborCol = col + direction[1];
            var isOutOfBounds = neighborRow < 0
                                || neighborCol < 0
                                || neighborRow >= image.Length
                                || neighborCol >= image[neighborRow].Length;
            if (isOutOfBounds 
                ||  image[neighborRow][neighborCol] != color 
                || visited.Contains((neighborRow, neighborCol)))
                continue;
            result.Add((neighborRow, neighborCol));
        }

        return result;
    }
}