namespace Problems.Google.GraphsTrees;

public class LongestIncreasingPath
{
    private int[][] _directions = new[]
    {
        new[] {-1, 0}, //top
        new[] {0, -1}, //left
        new[] {0, 1}, //right
        new[] {1, 0} //bottom
    };

    #region Dfs

    /*
     * This approach although correct is naive and will throw an time limit exceeded when ran on
     * leetcode
     */
    public int Get(int[][] matrix)
    {
        if (matrix is null || matrix.Length == 0)
            return 0;
        int maxPath = 0;

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++ )
            {
                maxPath = Math.Max(maxPath, Dfs(matrix, row, col));
            }
        }
        
        return maxPath;
    }

    int Dfs(int[][] matrix ,int row, int col)
    {
        int max = 0;
        foreach (var direction in _directions)
        {
            var directionRow = row + direction[0];
            var directionCol= col + direction[1];
            int source = matrix[row][col];
            

            var isOutOfBounds = directionRow < 0
                                || directionCol < 0
                                || directionRow >= matrix.Length
                                || directionCol >= matrix[row].Length;

            if (!isOutOfBounds && matrix[directionRow][directionCol] > source)
            {
                max = Math.Max(max, Dfs(matrix, directionRow, directionCol));
            }
        }

        return ++max;
    }

    #endregion

    #region Dfs Memoization

    public int GetDfsMemoization(int[][] matrix)
    {
        if (matrix is null || matrix.Length == 0)
            return 0;
        int maxPath = 0;
        int[,] cache = new int[matrix.Length,matrix[0].Length];

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++ )
            {
                maxPath = Math.Max(maxPath, Dfs(matrix, row, col, cache));
            }
        }
        
        return maxPath;
    }
    
    int Dfs(int[][] matrix ,int row, int col, int[,] cache)
    {
        if (cache[row, col] != 0) return cache[row, col];
        foreach (var direction in _directions)
        {
            var directionRow = row + direction[0];
            var directionCol= col + direction[1];
            int source = matrix[row][col];
            

            var isOutOfBounds = directionRow < 0
                                || directionCol < 0
                                || directionRow >= matrix.Length
                                || directionCol >= matrix[row].Length;

            if (!isOutOfBounds && matrix[directionRow][directionCol] > source)
            {
                cache[row,col] = Math.Max(cache[row,col], Dfs(matrix, directionRow, directionCol, cache));
            }
        }

        return ++cache[row,col];
    }
    #endregion
}