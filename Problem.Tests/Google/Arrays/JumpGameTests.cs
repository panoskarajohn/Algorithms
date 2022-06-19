using FluentAssertions;
using Problems.Google.Arrays;

namespace Problem.Tests.Google.Arrays;

public class JumpGameTests
{
    [Theory]
    [InlineData(new[] {2, 3, 1, 1, 4}, true)]
    [InlineData(new[] {3, 2, 1, 0, 4}, false)]
    [InlineData(new[] {1, 2, 3}, true)]
    [InlineData(new[] {3, 0, 8, 2, 0, 0, 1}, true)]
    public void Jump_Game_Tests(int[] nums, bool expected)
    {
        var resuolt = JumpGame.Execute(nums);
        resuolt.Should().Be(expected);
    }
}