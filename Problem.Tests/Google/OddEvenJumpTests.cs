using FluentAssertions;
using Problems.Google;
using Xunit;

namespace Problem.Tests.Google;

public class OddEvenJumpTests
{
    [Theory]
    [InlineData(new int[] { 10, 13, 12, 14, 15 },2)]
    [InlineData(new int[] { 2,3,1,1,4},3)]
    [InlineData(new int[] { 5,1,3,4,2},3)]
    [InlineData(new int[] { 14,13,15},3)]
    public void Odd_Even_Jump_Tests(int[] array , int expected)
    {
        var result = OddEvenJump.OddEvenJumps(array);
        result.Should().Be(expected);
    }
}