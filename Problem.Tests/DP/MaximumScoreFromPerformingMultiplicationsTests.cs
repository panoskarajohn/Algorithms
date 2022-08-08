using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class MaximumScoreFromPerformingMultiplicationsTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {1, 2, 3},
                    new[] {3, 2, 1},
                    14
                },
                new object[]
                {
                    new[] {-5, -3, -3, -2, 7, 1},
                    new[] {-10, -5, 3, 4, 6},
                    102
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Maximum_score_from_performing_multiplications_tests(int[] data, int[] mult, int expected)
    {
        var result = new MaximumScoreFromPerformingMultiplications().MaximumScore(data, mult);
        result.Should().Be(expected);
    }
}