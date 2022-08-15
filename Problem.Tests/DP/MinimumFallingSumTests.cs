using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class MinimumFallingSumTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Minimum_falling_sum_tests(int[][] data, int expected)
    {
        var result = new MinimumPathFallingSum().MinFallingPathSum(data);
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
                    new[] {new[] {2, 1, 3}, new[] {6, 5, 4}, new[] {7,8,9}},
                    13
                },
                new object[]
                {
                    new[] {new[] {-19, 57}, new[] { -40, -5 }},
                    -59
                },
                new object[]
                {
                    new[] {new[] {-48}},
                    -48
                },
            };
        }
    }
}