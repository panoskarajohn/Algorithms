using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class MinimumPathSumTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Minimum_path_sum_tests(int[][] data, int expected)
    {
        var result = new MinimumPathSum().Get(data);
        result.Should().Be(expected);

    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {new[] {1, 3, 1}, new[] {1, 5, 1}, new[] {4, 2, 1}},
                    7
                },
                new object[]
                {
                    new[] {new[] {1, 2, 3}, new[] {4, 5, 6}},
                    12
                },
            };
        }
    }
}