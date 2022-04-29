using FluentAssertions;
using Problems.Google.Arrays;
using Xunit;

namespace Problem.Tests.Google.Arrays;

public class LongestSubstringWithAtMostTwoCharsDistinctTests
{
    [Theory]
    [InlineData("eceba", 3)]
    [InlineData("ccaabbb", 5)]
    public void Longest_Substring_With_At_Most_Two_CharsDistinctTests(string s, int expected)
    {
        var result = LongestSubstringWithAtMostTwoCharsDistinct.Get(s);
        result.Should().Be(expected);
    }
}