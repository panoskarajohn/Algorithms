using System.Collections.Generic;
using Problems.Google.GraphsTrees;
using Xunit;

namespace Problem.Tests.Google.GraphsTrees;


public class ShortestPathInBinaryMatrixTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Shortest_Path_In_Binary_Matrix_Tests(int[][] data, int expected)
    {
        var solution = new ShortestPathInBinaryMatrix();
        var result = solution.GetShortestPath(data);
        Assert.Equal(result, expected);
    }

    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {new[] {0, 1}, new[] {1, 0}},
                    2
                },
                new object[]
                {
                    new[] {new[] {0, 0, 0}, new[] {1,1,0}, new[] {1,1,0}},
                    4
                },
                new object[]
                {
                    new[] {new[] {1, 0, 0}, new[] {1,1,0}, new[] {1,1,0}},
                    -1
                }
                
                
            };
        }
    }
}