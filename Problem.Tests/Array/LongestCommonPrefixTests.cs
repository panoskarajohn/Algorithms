using FluentAssertions;
using Problems.Array;
using Xunit;

namespace Problem.Tests.Array;

public class LongestCommonPrefixTests
{
    [Theory]
    [InlineData(new string[] {"flower", "flow", "flight"}, "fl")]
    [InlineData(new string[] {"dog", "racecar", "car"}, "")]
    [InlineData(new string[] {"a"}, "a")]
    public void Longest_Common_Prefix_Tests(string[] strs, string expected)
    {
        var result = LongestCommonPrefix.Execute(strs);
        result.Should().Be(expected);
    }
}