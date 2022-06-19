namespace Problems.Google.GraphsTrees;

public class ShortestPathInBinaryMatrix
{
    /// <summary>
    ///     all directions { row, col }
    /// </summary>
    private static readonly (int row, int col)[] _direction =
    {
        (-1, -1),
        (-1, 0),
        (-1, 1),
        (0, -1),
        (0, 1),
        (1, -1),
        (1, 0),
        (1, 1)
    };

    public int GetShortestPath(int[][] grid)
    {
        if (grid == null ||
            grid.Length == 0 ||
            grid[0].Length == 0 ||
            grid[0][0] != 0 ||
            grid[^1][grid[0].Length - 1] != 0)
            return -1;

        var queue = new Queue<int[]>();
        queue.Enqueue(new[] {0, 0});
        grid[0][0] = 1;

        while (queue.Any())
        {
            var current = queue.Dequeue();
            var distance = grid[current[0]][current[1]];

            if (current[0] == grid.Length - 1 && current[1] == grid[0].Length - 1) return distance;


            var neighbors = GetNeighbors(current[0], current[1], grid);
            foreach (var neighbor in neighbors)
            {
                var neighborRow = neighbor[0];
                var neighborCol = neighbor[1];
                queue.Enqueue(new[] {neighborRow, neighborCol});
                grid[neighborRow][neighborCol] = distance + 1;
            }
        }

        return -1;
    }

    private List<int[]> GetNeighbors(int row, int col, int[][] grid)
    {
        var neighbors = new List<int[]>();

        foreach (var direction in _direction)
        {
            var newRow = row + direction.row;
            var newCol = col + direction.col;

            if (newRow < 0 || newCol < 0) continue;
            if (newCol >= grid[0].Length || newRow >= grid.Length) continue;
            if (grid[newRow][newCol] != 0) continue;

            neighbors.Add(new[] {newRow, newCol});
        }

        return neighbors;
    }
}