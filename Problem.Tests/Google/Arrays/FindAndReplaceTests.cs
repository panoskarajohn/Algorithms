using FluentAssertions;
using Problems.Google.Arrays;
using Xunit;

namespace Problem.Tests.Google.Arrays;

public class FindAndReplaceTests
{
    [Theory]
    [InlineData("abcd", new []{ 0,2 }, new[] { "a", "cd" }, new[] { "eee", "ffff" }, "eeebffff")]
    [InlineData("abcd", new []{ 0,2 }, new[] { "ab", "ec" }, new[] { "eee", "ffff" }, "eeecd")]
    [InlineData("vmokgggqzp", new []{ 3,5,1 }, new[] { "kg", "ggq", "mo" }, new[] { "s", "so", "bfr" }, "vbfrssozp")]
    [InlineData("abcde", new []{ 2, 2 }, new[] { "cdef", "bc" }, new[] { "f", "fe" }, "abcde")]
    public void Find_And_Replace_Tests(string s, int[] indices, string[] sources, string[] targets, string expected)
    {
        var result = FindAndReplace.FindReplaceString(s, indices, sources, targets);
        result.Should().Be(expected);
    }
}