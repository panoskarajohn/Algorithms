using FluentAssertions;
using Problems.Google.Arrays;

namespace Problem.Tests.Google.Arrays;

public class MaximizeDistanceToClosestPersonTests
{
    [Theory]
    [InlineData(new[] {1, 0, 0, 0, 1, 0, 1}, 2)]
    [InlineData(new[] {1, 0, 0, 0}, 3)]
    [InlineData(new[] {0, 0, 1, 0, 1, 1}, 2)]
    [InlineData(new[] {0, 1}, 1)]
    public void Maximize_Distance_To_Closest_Person_Tests(int[] seats, int expected)
    {
        var result = MaximizeDistanceToClosestPerson.Get(seats);
        result.Should().Be(expected);
    }
}