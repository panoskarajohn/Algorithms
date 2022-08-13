using FluentAssertions;
using Problems.Google.DP;

namespace Problem.Tests.Google.DP;

public class LongestPalindromicSubstringTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "babad",
                    "aba"
                },
                new object[]
                {
                    "cbbd",
                    "bb"
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Longest_Palindromic_Substring_Tests(string s, string expected)
    {
        var result = new LongestPalindromicSubstring().Get(s);
        result.Should().Be(expected);
    }
}