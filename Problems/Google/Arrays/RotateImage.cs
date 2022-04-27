using System.ComponentModel.DataAnnotations;

namespace Problems.Google.Arrays;

public class RotateImage
{
    public static void RotateBrute(int[][] matrix)
    {
        var temp = matrix.Select(s => s.ToArray()).ToArray();
        int n = matrix.Length - 1;
        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix.Length; col++)
            {
                matrix[col][n] = temp[row][col];
            }

            n--;
        }

    }

    /// <summary>
    /// No allocation of second temp array
    /// </summary>
    /// <param name="matrix"></param>
    public static void Rotate(int[][] matrix)
    {
        int n = matrix.Length;

        for (int i = 0; i < (n + 1) / 2; i++)
        {
            for (int j = 0; j < n  / 2; j++)
            {
                int temp = matrix[n - 1 - j][i];
                matrix[n - 1 - j][i] = matrix[n - 1 - i][n - j - 1];
                matrix[n - 1 - i][n - j - 1] = matrix[j][n - 1 -i];
                matrix[j][n - 1 - i] = matrix[i][j];
                matrix[i][j] = temp;
            }
        }
    }
}