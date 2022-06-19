using FluentAssertions;
using Problems.Google.Arrays;

namespace Problem.Tests.Google.Arrays;

public class BackspaceStringCompareTests
{
    [Theory]
    [InlineData("ab#c", "ad#c", true)]
    [InlineData("ab##", "c#d#", true)]
    [InlineData("a#c", "b", false)]
    public void Backspace_String_Compare_Tests(string s, string t, bool expected)
    {
        var result = BackspaceStringCompare.Compare(s, t);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("ab#c", "ad#c", true)]
    [InlineData("ab##", "c#d#", true)]
    [InlineData("a#c", "b", false)]
    public void Backspace_String_Compare_Optimal_Tests(string s, string t, bool expected)
    {
        var result = BackspaceStringCompare.CompareOptimal(s, t);
        result.Should().Be(expected);
    }
}