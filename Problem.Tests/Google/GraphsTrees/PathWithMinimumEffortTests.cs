using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class PathWithMinimumEffortTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {new[] {1, 2, 2}, new[] {3, 8, 2}, new[] {5, 3, 5}},
                    2
                },
                new object[]
                {
                    new[] {new[] {1, 2, 3}, new[] {3, 8, 4}, new[] {5, 3, 5}},
                    1
                },
                new object[]
                {
                    new[]
                    {
                        new[] {1, 2, 1, 1, 1}, new[] {1, 2, 1, 2, 1}, new[] {1, 2, 1, 2, 1}, new[] {1, 2, 1, 2, 1},
                        new[] {1, 1, 1, 2, 1}
                    },
                    0
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Path_w_ith_minimum_effort_tests(int[][] heights, int expected)
    {
        var result = new PathWithMinimumEffort().Get(heights);
        result.Should().Be(expected);
    }
}