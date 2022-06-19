using FluentAssertions;
using Problems.Array;

namespace Problem.Tests.Array;

public class LongestCommonPrefixTests
{
    [Theory]
    [InlineData(new[] {"flower", "flow", "flight"}, "fl")]
    [InlineData(new[] {"dog", "racecar", "car"}, "")]
    [InlineData(new[] {"a"}, "a")]
    public void Longest_Common_Prefix_Tests(string[] strs, string expected)
    {
        var result = LongestCommonPrefix.Execute(strs);
        result.Should().Be(expected);
    }
}