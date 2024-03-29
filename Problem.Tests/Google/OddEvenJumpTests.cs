﻿using FluentAssertions;
using Problems.Google;

namespace Problem.Tests.Google;

public class OddEvenJumpTests
{
    [Theory]
    [InlineData(new[] {10, 13, 12, 14, 15}, 2)]
    [InlineData(new[] {2, 3, 1, 1, 4}, 3)]
    [InlineData(new[] {5, 1, 3, 4, 2}, 3)]
    [InlineData(new[] {14, 13, 15}, 3)]
    [InlineData(new[] {81, 54, 96, 60, 58}, 2)]
    public void Odd_Even_Jump_Tests(int[] array, int expected)
    {
        var result = OddEvenJump.OddEvenJumps(array);
        result.Should().Be(expected);
    }
}