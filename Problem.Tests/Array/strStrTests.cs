using FluentAssertions;
using Xunit;

namespace Problem.Tests.Array;

public class strStrTests
{
    [Theory]
    [InlineData("mississippi", "issip", 4)]
    [InlineData("mississippi", "pi", 9)]
    [InlineData("hello", "ll", 2)]
    [InlineData("aaaaa", "bba", -1)]
    public void str_Str_Tests(string haystack, string needle, int expected)
    {
        var result = StrStr.Execute(haystack, needle);
        result.Should().Be(expected);
    }
}