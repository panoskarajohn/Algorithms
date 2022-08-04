using FluentAssertions;

namespace Problem.Tests.Amazon.Arrays;

public class GenerateMatrixTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Generate_matrix_tests(int n, int[][] expected)
    {
        var res = new SpiralMatrixTwo().GenerateMatrix(n);
        res.Should().BeEquivalentTo(expected);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    3,
                    new[] {new[] {1, 2, 3}, new[] {8, 9, 4}, new[] {7,6, 5}},
                }
            };
        }
    }
}

public class SpiralMatrixTwo
{
    public int[][] GenerateMatrix(int n) {
        int counter = 1;
        
        //initialize array
        int[][] result = new int[n][];
        for (int i = 0; i < n; i++)
            result[i] = new int[n];
        
        int top = 0;
        int bottom = result.Length - 1;
        int left = 0; 
        int right = result[0].Length - 1;
        
        int size = result.Length * result[0].Length;
        
        while(counter <= size)
        {
            for(int i = left; i <= right && counter <= size; i++)
            {
                result[top][i] = counter++;
            }
            
            top++;
            for(int i = top; i <= bottom && counter <= size; i++)
            {
                result[i][right] = counter++;
            }
            right--;
            
            for(int i = right; i >= left && counter <= size; i--)
            {
                result[bottom][i] = counter++;
            }
            bottom--;
            
            for(int i = bottom; i >= top && counter <= size; i--)
            {
                result[i][left] = counter++;
            }
            left++;
        }
        
        
        return result;
    }
}