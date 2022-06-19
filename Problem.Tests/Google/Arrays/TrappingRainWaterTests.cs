using FluentAssertions;
using Problems.Google.Arrays;

namespace Problem.Tests.Google.Arrays;

public class TrappingRainWaterTests
{
    [Theory]
    [InlineData(new[] {0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1}, 6)]
    [InlineData(new[] {4, 2, 0, 3, 2, 5}, 9)]
    public void Trapping_Rain_Water_Tests(int[] heights, int expected)
    {
        var trappedWater = TrappingRainWater.Get(heights);
        trappedWater.Should().Be(expected);
    }

    [Theory]
    [InlineData(new[] {0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1}, 6)]
    [InlineData(new[] {4, 2, 0, 3, 2, 5}, 9)]
    public void Trapping_Rain_Water_TwoPointers_Tests(int[] heights, int expected)
    {
        var trappedWater = TrappingRainWater.GetTwoPointersApproach(heights);
        trappedWater.Should().Be(expected);
    }
}