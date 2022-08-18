using FluentAssertions;
using Problems.Series.PaintHouse;

namespace Problem.Tests.Series.PaintHouse;

public class PaintHouseThreeTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {0, 0, 0, 0, 0},
                    new[] {new[] {1, 10}, new[] {10, 1}, new[] {10, 1}, new[] {1, 10}, new[] {5, 1}},
                    5,
                    2,
                    3,
                    9
                },
                new object[]
                {
                    new[] {0, 2, 1, 2, 0},
                    new[] {new[] {1, 10}, new[] {10, 1}, new[] {10, 1}, new[] {1, 10}, new[] {5, 1}},
                    5,
                    2,
                    3,
                    11
                },
                new object[]
                {
                    new[] {3, 1, 2, 3},
                    new[] {new[] {1, 1, 1}, new[] {1, 1, 1}, new[] {1, 1, 1}, new[] {1, 1, 1}},
                    4,
                    3,
                    3,
                    -1
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Paint_house_three_tests(int[] houses, int[][] costs, int m, int n, int target, int expected)
    {
        var result = new PaintHouseThree().MinCostTopDown(houses, costs, m, n, target);
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Paint_house_three_bottom_up_tests(int[] houses, int[][] costs, int m, int n, int target, int expected)
    {
        var result = new PaintHouseThree().MinCostBottomUp(houses, costs, m, n, target);
        result.Should().Be(expected);
    }
}