using FluentAssertions;
using Problems.Google.Arrays;
using Xunit;

namespace Problem.Tests.Google.Arrays;

public class NextClosestTimeTests
{
    [Theory]
    [InlineData("19:34", "19:39")]
    [InlineData("23:59", "22:22")]
    [InlineData("01:32", "01:33")]
    public void Next_Closest_Time_Tests(string time, string expected)
    {
        var result = NextClosestTime.Get(time);
        result.Should().Be(expected);
    }
}