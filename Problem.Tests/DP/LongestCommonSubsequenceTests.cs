using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class LongestCommonSubsequenceTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "abcde",
                    "ace",
                    3
                },
                new object[]
                {
                    "abc",
                    "abc",
                    3
                },
                new object[]
                {
                    "abc",
                    "def",
                    0
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Longest_common_subsequence_tests(string text1, string text2, int expected)
    {
        var result = new LongestCommonSubsequence().Get(text1, text2);
        result.Should().Be(expected);
    }
}