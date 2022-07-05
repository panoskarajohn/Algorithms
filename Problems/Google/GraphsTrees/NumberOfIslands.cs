using System.ComponentModel;

namespace Problems.Google.GraphsTrees;

public class NumberOfIslands
{
    private int[][] _directions = new[]
    {
        new[] {1, 0}, // top
        new[] {-1, 0}, //bottom
        new[] {0, 1}, //right
        new[] {0, -1}, //left
    };
    public int NumIslands(char[][] grid)
    {
        if (grid is null || grid.Length == 0)
            return 0;

        int numIslands = 0;
        var visited = new HashSet<(int row, int col) >();

        for (int row = 0; row < grid.Length; row++)
        {
            for (int col = 0; col < grid[row].Length; col++)
            {
                var current = grid[row][col];
                if (!visited.Contains((row, col)) && current == '1')
                {
                    Bfs(row, col, visited, grid);
                    numIslands++;
                }
            }
        }
        return numIslands;
    }

    void Bfs(int row, int col, HashSet<(int row, int col)> visited, char[][] grid)
    {
        var que = new Queue<(int row, int col)>();
        que.Enqueue((row, col));
        visited.Add((row, col));
        while (que.Any())
        {
            var current = que.Dequeue();
            foreach (var direction in _directions)
            {
                var neighborRow = current.row + direction[0];
                var neighborCol = current.col + direction[1];
                var isOutOfBounds = neighborRow < 0 
                                    || neighborCol < 0 
                                    || neighborRow >= grid.Length 
                                    || neighborCol >= grid[row].Length;
                
                if(isOutOfBounds ) continue;
                
                var isValidIsland = grid[neighborRow][neighborCol] == '1';
                var isNotVisited = !visited.Contains((neighborRow, neighborCol));
                
                if (isNotVisited && isValidIsland)
                {
                    que.Enqueue((neighborRow, neighborCol));
                    visited.Add((neighborRow, neighborCol));
                }
            }
        }

    }
}