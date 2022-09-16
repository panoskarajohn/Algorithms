using FluentAssertions;
using Problems.DP.OneDimension;

namespace Problem.Tests.DP.OneDimension;

public class ClimbingStairsTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    1,
                    1
                },
                new object[]
                {
                    2,
                    2
                },
                new object[]
                {
                    3,
                    3
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Climbing_stairs_Tests(int steps, int expected)
    {
        var result = new ClimbingStairs().Climb(steps);
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Climbing_stairs_bottom_up_Tests(int steps, int expected)
    {
        var result = new ClimbingStairs().ClimbBottomUp(steps);
        result.Should().Be(expected);
    }
}