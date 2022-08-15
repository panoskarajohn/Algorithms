namespace Problems.DP;

public class MinimumPathSum
{
    public int Get(int[][] grid)
    {
        int row = grid.Length;
        int col = grid[0].Length;
        
        //
        for (int i = 1; i < row; i++)
        {
            grid[i][0] += grid[i - 1][0];
        }

        for (int i = 1; i < col; i++)
        {
            grid[0][i] += grid[0][i - 1];
        }

        for (int i = 1; i < row; i++)
        {
            for (int j = 1; j < col; j++)
            {
                var current = grid[i][j];
                var top = grid[i - 1][j] + current;
                var left = grid[i][j - 1] + current;
                
                grid[i][j] = Math.Min(top, left);
            }
        }

        return grid[^1][^1];
    }
}