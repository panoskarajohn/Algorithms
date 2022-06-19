namespace Problems.Google.GraphsTrees;

public class RottingOranges
{
    /// <summary>
    ///     4-directionally adjacent directions
    /// </summary>
    public int OrangesRotting(int[][] grid)
    {
        var time = -1;
        var freshOranges = 0;
        var queue = new Queue<(int row, int col)>();

        for (var i = 0; i < grid.Length; i++)
        for (var j = 0; j < grid[0].Length; j++)
        {
            if (grid[i][j] == 2) queue.Enqueue((i, j));

            if (grid[i][j] == 1) freshOranges++;
        }

        queue.Enqueue((-1, -1));

        if (freshOranges == 0)
            return 0;

        while (queue.Any())
        {
            var poll = queue.Dequeue();

            if (poll.row == -1)
            {
                time++;
                if (queue.Any()) queue.Enqueue((-1, -1));
                continue;
            }

            var neighbors = GetNeighbors(poll.row, poll.col, grid);

            foreach (var neighbor in neighbors)
                if (grid[neighbor.row][neighbor.col] == 1)
                {
                    grid[neighbor.row][neighbor.col] = 2;
                    queue.Enqueue(neighbor);
                    freshOranges--;
                }
        }

        if (freshOranges > 0)
            return -1;

        return time;
    }

    private IList<(int row, int col)> GetNeighbors(int row, int col, int[][] grid)
    {
        int[][] directions =
        {
            new[] {-1, 0},
            new[] {0, -1},
            new[] {0, 1},
            new[] {1, 0}
        };
        var neighbors = new List<(int row, int col)>();

        foreach (var direction in directions)
        {
            var newRow = row + direction[0];
            var newCol = col + direction[1];

            if (newRow < 0 ||
                newRow >= grid.Length ||
                newCol < 0 ||
                newCol >= grid[0].Length)
                continue;

            neighbors.Add((newRow, newCol));
        }

        return neighbors;
    }
}