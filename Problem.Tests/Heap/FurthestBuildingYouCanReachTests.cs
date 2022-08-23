using FluentAssertions;
using Problems.Heap;

namespace Problem.Tests.Heap;

public class FurthestBuildingYouCanReachTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {4, 12, 2, 7, 3, 18, 20, 3, 19},
                    10,
                    2,
                    7
                },
                new object[]
                {
                    new[] {14, 3, 19, 3},
                    17,
                    0,
                    3
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Furthest_building_you_can_reach_tests(int[] data, int bricks, int ladders, int expected)
    {
        var result = new FurthestBuildingYouCanReach().FurthestBuilding(data, bricks, ladders);
        result.Should().Be(expected);
    }
}