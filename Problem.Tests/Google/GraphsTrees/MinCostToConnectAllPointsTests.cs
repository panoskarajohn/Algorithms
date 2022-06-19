using System.Collections.Generic;
using Problems.Google.GraphsTrees;
using Xunit;

namespace Problem.Tests.Google.GraphsTrees;

public class MinCostToConnectAllPointsTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Min_Cost_To_Connect_All_Points_Tests(int[][] points, int expected)
    {
        var actual = new MinCostToConnectAllPoints()
            .MinCost(points);
        Assert.Equal(expected, actual);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    
                    new[] {new[] {0, 0}, new[] {2, 2}, new[] {3, 10}, new[] {7, 0}},
                    20
                },
                new object[]
                {
                    new[] {new[] {3, 12}, new[] {-2, 5}, new[] {-4, 1}},
                    18
                },
            };
        }
    }
}