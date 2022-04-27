using FluentAssertions;
using Problems.Google.Arrays;
using Xunit;

namespace Problem.Tests.Google.Arrays;

public class JumpGameTests
{
    [Theory]
    [InlineData(new int[] { 2,3,1,1,4 }, true)]
    [InlineData(new int[] { 3,2,1,0,4 }, false)]
    [InlineData(new int[] { 1,2,3}, true)]
    [InlineData(new int[] { 3,0,8,2,0,0,1 }, true)]
    public void Jump_Game_Tests(int[] nums, bool expected)
    {
        var resuolt =  JumpGame.Execute(nums);
        resuolt.Should().Be(expected);
    }
}