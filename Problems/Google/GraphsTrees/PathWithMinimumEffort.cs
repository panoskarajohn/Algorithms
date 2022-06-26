namespace Problems.Google.GraphsTrees;

public class PathWithMinimumEffort
{
    private int[][] _directions =
    {
        new[] {0, 1},
        new[] {1, 0},
        new[] {0, -1},
        new[] {-1, 0}
    };

    public int Get(int[][] heights)
    {
        int rows = heights.Length;
        int cols = heights[0].Length;
        var differenceMatrix = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            differenceMatrix[i] = new int[cols];
            System.Array.Fill(differenceMatrix[i], int.MaxValue);
        }

        differenceMatrix[0][0] = 0;
        PriorityQueue<Cell, int> heap = new PriorityQueue<Cell, int>();

        bool[][] visited = new bool[rows][];
        for (int i = 0; i < rows; i++)
            visited[i] = new bool[cols];

        heap.Enqueue(new Cell(0, 0, differenceMatrix[0][0]), differenceMatrix[0][0]);

        while (heap.Count != 0)
        {
            var currentCell = heap.Dequeue();
            visited[currentCell.x][currentCell.y] = true;

            if (currentCell.x == rows - 1 && currentCell.y == cols - 1)
            {
                return currentCell.difference;
            }

            foreach (var direction in _directions)
            {
                int adjacentX = currentCell.x + direction[0];
                int adjacentY = currentCell.y + direction[1];

                if (IsValidCell(adjacentX, adjacentY, rows, cols) && !visited[adjacentX][adjacentY])
                {
                    int currentDifference =
                        Math.Abs(heights[adjacentX][adjacentY] - heights[currentCell.x][currentCell.y]);
                    int maxDifference = Math.Max(currentDifference, differenceMatrix[currentCell.x][currentCell.y]);

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
    
    bool IsValidCell(int x, int y, int row, int col) {
        return x >= 0 && x <= row - 1 && y >= 0 && y <= col - 1;
    }

    class Cell
    {
        public int x;
        public int y;
        public int difference;

        public Cell(int x, int y, int difference) {
            this.x = x;
            this.y = y;
            this.difference = difference;
        }
    }
}