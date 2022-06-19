namespace Problems.Google.Arrays;

public class RotateImage
{
    public static void RotateBrute(int[][] matrix)
    {
        var temp = matrix.Select(s => s.ToArray()).ToArray();
        var n = matrix.Length - 1;
        for (var row = 0; row < matrix.Length; row++)
        {
            for (var col = 0; col < matrix.Length; col++) matrix[col][n] = temp[row][col];

            n--;
        }
    }

    /// <summary>
    ///     No allocation of second temp array
    /// </summary>
    /// <param name="matrix"></param>
    public static void Rotate(int[][] matrix)
    {
        var n = matrix.Length;

        for (var i = 0; i < (n + 1) / 2; i++)
        for (var j = 0; j < n / 2; j++)
        {
            var temp = matrix[n - 1 - j][i];
            matrix[n - 1 - j][i] = matrix[n - 1 - i][n - j - 1];
            matrix[n - 1 - i][n - j - 1] = matrix[j][n - 1 - i];
            matrix[j][n - 1 - i] = matrix[i][j];
            matrix[i][j] = temp;
        }
    }
}