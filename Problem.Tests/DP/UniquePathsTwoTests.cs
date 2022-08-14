using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class UniquePathsTwoTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {new[] {0, 0, 0}, new[] {0, 1, 0}, new[] {0, 0, 0}},
                    2
                },
                new object[]
                {
                    new[] {new[] {0, 1}, new[] {0, 0}},
                    1
                },
                new object[]
                {
                    new[] {new[] {0, 1}},
                    0
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Unique_paths_two_tests(int[][] data, int expected)
    {
        var result = new UniquePathsTwo().UniquePathsWithObstacles(data);
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Unique_paths_two_DP_tests(int[][] data, int expected)
    {
        var result = new UniquePathsTwo().UniquePathsWithObstaclesDP(data);
        result.Should().Be(expected);
    }
}