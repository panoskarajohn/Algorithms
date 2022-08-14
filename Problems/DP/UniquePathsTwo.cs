namespace Problems.DP;

public class UniquePathsTwo
{
    #region Dfs

    private int _sizeRow;
    private int _sizeCol;

    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        _sizeRow = obstacleGrid.Length;
        _sizeCol = obstacleGrid[0].Length;
        var memo = new int[_sizeRow][];
        for (var i = 0; i < _sizeRow; i++) memo[i] = new int[_sizeCol];

        if (obstacleGrid[0][0] == 1)
            return 0;
        return Dfs(0, 0, memo, obstacleGrid);
    }
    
    private int Dfs(int row, int col, int[][] memo, in int[][] grid)
    {
        if (row == _sizeRow - 1 && col == _sizeCol - 1 && grid[row][col] == 1)
            return 0;
        if (row == _sizeRow - 1 && col == _sizeCol - 1)
            return 1;

        if (memo[row][col] != 0)
            return memo[row][col];

        var sum = 0;
        foreach (var direction in GetDirections(row, col))
            if (grid[direction.row][direction.col] != 1)
                sum += Dfs(direction.row, direction.col, memo, grid);
        memo[row][col] = sum;
        return sum;
    }

    private List<(int row, int col)> GetDirections(int row, int col)
    {
        int[][] _directions =
        {
            new[] {0, 1},
            new[] {1, 0}
        };

        var result = new List<(int row, int col)>();

        foreach (var direction in _directions)
        {
            var newRow = row + direction[0];
            var newCol = col + direction[1];

            if (newRow < 0 || newRow >= _sizeRow)
                continue;

            if (newCol < 0 || newCol >= _sizeCol)
                continue;

            result.Add((newRow, newCol));
        }

        return result;
    }

    #endregion

    #region Dynamic programming approach

    public int UniquePathsWithObstaclesDP(int[][] obstacleGrid)
    {
        int row = obstacleGrid.Length;
        int col = obstacleGrid[0].Length;
        
        //if the starting cell has an obstacle, then simply return as there would be
        //no paths to the destination
        if (obstacleGrid[0][0] == 1)
            return 0;
        
        //number of ways of reaching the starting cell = 1
        obstacleGrid[0][0] = 1;
        
        //fill the first column
        // if the current value is 0 and the above one is 1 then we can set the ways to 1 otherwise 0
        for (int i = 1; i < row; i++)
        {
            if (obstacleGrid[i][0] == 0 && obstacleGrid[i - 1][0] == 1)
                obstacleGrid[i][0] = 1;
            else
            {
                obstacleGrid[i][0] = 0;
            }
        }

        for (int i = 1; i < col; i++)
        {
            if (obstacleGrid[0][i] == 0 && obstacleGrid[0][i - 1] == 1)
                obstacleGrid[0][i] = 1;
            else
            {
                obstacleGrid[0][i] = 0;
            }
        }

        for (int i = 1; i < row; i++)
        {
            for (int j = 1; j < col; j++)
            {
                if (obstacleGrid[i][j] == 0)
                {
                    var top = obstacleGrid[i - 1][j];
                    var left = obstacleGrid[i][j - 1];
                    obstacleGrid[i][j] = top + left;
                }
                else
                {
                    obstacleGrid[i][j] = 0;
                }
                    
            }
        }

        return obstacleGrid[row - 1][col - 1];
    }

    #endregion
}