using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class MaximalSquaresTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[]
                    {
                        new[] {'1', '0', '1', '0', '0'}, new[] {'1', '0', '1', '1', '1'},
                        new[] {'1', '1', '1', '1', '1'}, new[] {'1', '0', '0', '1', '0'}
                    },
                    4
                },
                new object[]
                {
                    new[]
                    {
                        new[] { '0', '1'}, new[] {'1', '0'}
                    },
                    1
                },
                new object[]
                {
                    new[]
                    {
                        new[] { '0'}
                    },
                    0
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Maximal_squares_tests(char[][] matrix, int expected)
    {
        var result = new MaximalSquare().Get(matrix);
        result.Should().Be(expected);
    }
}