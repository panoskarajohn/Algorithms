using FluentAssertions;

namespace Problem.Tests.Amazon.Arrays;

public class GenerateMatrixTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    3,
                    new[] {new[] {1, 2, 3}, new[] {8, 9, 4}, new[] {7, 6, 5}}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Generate_matrix_tests(int n, int[][] expected)
    {
        var res = new SpiralMatrixTwo().GenerateMatrix(n);
        res.Should().BeEquivalentTo(expected);
    }
}

public class SpiralMatrixTwo
{
    public int[][] GenerateMatrix(int n)
    {
        var counter = 1;

        //initialize array
        var result = new int[n][];
        for (var i = 0; i < n; i++)
            result[i] = new int[n];

        var top = 0;
        var bottom = result.Length - 1;
        var left = 0;
        var right = result[0].Length - 1;

        var size = result.Length * result[0].Length;

        while (counter <= size)
        {
            for (var i = left; i <= right && counter <= size; i++) result[top][i] = counter++;

            top++;
            for (var i = top; i <= bottom && counter <= size; i++) result[i][right] = counter++;
            right--;

            for (var i = right; i >= left && counter <= size; i--) result[bottom][i] = counter++;
            bottom--;

            for (var i = bottom; i >= top && counter <= size; i--) result[i][left] = counter++;
            left++;
        }


        return result;
    }
}