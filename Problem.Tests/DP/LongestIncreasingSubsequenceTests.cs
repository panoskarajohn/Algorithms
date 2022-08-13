using FluentAssertions;
using Problem.Tests.Google.DP;

namespace Problem.Tests.DP;

public class LongestIncreasingSubsequenceTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {10, 9, 2, 5, 3, 7, 101, 18},
                    4
                },
                new object[]
                {
                    new[] {0, 1, 0, 3, 2, 3},
                    4
                },
                new object[]
                {
                    new[] {1, 2, 4, 3},
                    3
                },
                new object[]
                {
                    new[] {7, 7, 7, 7, 7, 7, 7},
                    1
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Longest_increasing_subsequence_tests(int[] data, int expected)
    {
        var result = new LongestIncreasingSubsequence().Get(data);
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Longest_increasing_subsequence_BS_tests(int[] data, int expected)
    {
        var result = new LongestIncreasingSubsequence().GetOpt(data);
        result.Should().Be(expected);
    }
}