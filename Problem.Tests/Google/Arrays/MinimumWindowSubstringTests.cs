using FluentAssertions;
using Problems.Google.Arrays;

namespace Problem.Tests.Google.Arrays;

public class MinimumWindowSubstringTests
{
    [Theory]
    [InlineData("ADOBECODEBANC", "ABC", "BANC")]
    [InlineData("a", "a", "a")]
    [InlineData("a", "aa", "")]
    public void Minimum_Window_Substring_Tests(string s, string t, string expected)
    {
        var result = MinimumWindowSubstring.Get(s, t);
        result.Should().Be(expected);
    }
}