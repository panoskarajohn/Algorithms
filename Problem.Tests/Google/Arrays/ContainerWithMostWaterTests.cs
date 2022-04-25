﻿using FluentAssertions;
using Problems.Google.Arrays;
using Xunit;

namespace Problem.Tests.Google.Arrays;

public class ContainerWithMostWaterTests
{
    [Theory]
    [InlineData(new int[] { 1,8,6,2,5,4,8,3,7 }, 49)]
    [InlineData(new int[] { 4,3,2,1,4 }, 16)]
    [InlineData(new int[] { 1,2,1}, 2)]
    public void Container_With_Most_Water_Tests(int[] height, int expectedArea)
    {
        var maxArea = ContainerWithMostWater.MaxArea(height);
        maxArea.Should().Be(expectedArea);
    }
}