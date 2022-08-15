using System.Text.RegularExpressions;

namespace Problems.DP;

public class MinimumPathFallingSum
{
    public int MinFallingPathSum(int[][] matrix)
    {

        if (matrix is null)
        {
            return 0;
        }

        int min = int.MaxValue;
        int row = matrix.Length;
        int col = matrix[0].Length;

        if (row == 1)
            return matrix[0].Min();

        for (int i = 1; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                var current = matrix[i][j];
                var top = matrix[i - 1][j] + current;
                var topLeft = (j - 1) < 0 ? int.MaxValue : matrix[i - 1][j - 1] + current;
                var topRight = (j + 1) >= col ? int.MaxValue : matrix[i - 1][j + 1] + current;

                matrix[i][j] = Math.Min(top, Math.Min(topLeft, topRight));

                if (i == row - 1)
                {
                    min = Math.Min(min, matrix[i][j]);
                }
            }
        }

        return min;
    }
}