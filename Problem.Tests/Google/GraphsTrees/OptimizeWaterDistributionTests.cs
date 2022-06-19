using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class OptimizeWaterDistributionTests
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
                    new[] {1, 2, 2},
                    new[] {new[] {1, 2, 1}, new[] {2, 3, 1}},
                    3
                },
                new object[]
                {
                    2,
                    new[] {1, 1},
                    new[] {new[] {1, 2, 1}, new[] {1, 2, 2}},
                    2
                },
                new object[]
                {
                    5,
                    new[] {46012, 72474, 64965, 751, 33304},
                    new[] {new[] {2, 1, 6719}, new[] {3, 2, 75312}, new[] {5, 3, 44918}},
                    131704
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Optimize_Water_Distribution_Tests(int n, int[] wells, int[][] pipes, int expected)
    {
        var result = OptimizeWaterDistribution.MinCostToSupplyWater(n, wells, pipes);
        result.Should().Be(expected);
    }
}