namespace Problems.Google.GraphsTrees;

public class PathWithMinimumEffort
{
    private readonly int[][] _directions =
    {
        new[] {0, 1},
        new[] {1, 0},
        new[] {0, -1},
        new[] {-1, 0}
    };

    public int Get(int[][] heights)
    {
        var rows = heights.Length;
        var cols = heights[0].Length;
        var differenceMatrix = new int[rows][];

        for (var i = 0; i < rows; i++)
        {
            differenceMatrix[i] = new int[cols];
            System.Array.Fill(differenceMatrix[i], int.MaxValue);
        }

        differenceMatrix[0][0] = 0;
        var heap = new PriorityQueue<Cell, int>();

        var visited = new bool[rows][];
        for (var i = 0; i < rows; i++)
            visited[i] = new bool[cols];

        heap.Enqueue(new Cell(0, 0, differenceMatrix[0][0]), differenceMatrix[0][0]);

        while (heap.Count != 0)
        {
            var currentCell = heap.Dequeue();
            visited[currentCell.x][currentCell.y] = true;

            if (currentCell.x == rows - 1 && currentCell.y == cols - 1) return currentCell.difference;

            foreach (var direction in _directions)
            {
                var adjacentX = currentCell.x + direction[0];
                var adjacentY = currentCell.y + direction[1];

                if (IsValidCell(adjacentX, adjacentY, rows, cols) && !visited[adjacentX][adjacentY])
                {
                    var currentDifference =
                        Math.Abs(heights[adjacentX][adjacentY] - heights[currentCell.x][currentCell.y]);
                    var maxDifference = Math.Max(currentDifference, differenceMatrix[currentCell.x][currentCell.y]);

                    if (differenceMatrix[adjacentX][adjacentY] > maxDifference)
                    {
                        differenceMatrix[adjacentX][adjacentY] = maxDifference;
                        heap.Enqueue(new Cell(adjacentX, adjacentY, maxDifference), maxDifference);
                    }
                }
            }
        }

        return differenceMatrix[rows - 1][cols - 1];
    }

    private bool IsValidCell(int x, int y, int row, int col)
    {
        return x >= 0 && x <= row - 1 && y >= 0 && y <= col - 1;
    }

    private class Cell
    {
        public readonly int difference;
        public readonly int x;
        public readonly int y;

        public Cell(int x, int y, int difference)
        {
            this.x = x;
            this.y = y;
            this.difference = difference;
        }
    }
}