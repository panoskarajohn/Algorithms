using FluentAssertions;
using Problems.Google.Arrays;
using Xunit;

namespace Problem.Tests.Google.Arrays;

public class LongestSubstringTests
{
    [Theory]
    [InlineData("abcabcbb", 3)]
    [InlineData("bbbbb", 1)]
    [InlineData("pwwkew", 3)]
    public void Longest_Substring_Brute_Tests(string s, int expected)
    {
        var result = LongestSubstring.LengthOfLongestSubstringBruteForce(s);
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("abcabcbb", 3)]
    [InlineData("bbbbb", 1)]
    [InlineData("pwwkew", 3)]
    public void Longest_Substring_Tests(string s, int expected)
    {
        var result = LongestSubstring.LengthOfLongestSubstring(s);
        result.Should().Be(expected);
    }
}