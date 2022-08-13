using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class MostStonesRemovedTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {new[] {0, 0}, new[] {0, 1}, new[] {1, 0}, new[] {1, 2}, new[] {2, 1}, new[] {2, 2}},
                    5
                },
                new object[]
                {
                    new[] {new[] {0, 0}, new[] {0, 2}, new[] {1, 1}, new[] {2, 0}, new[] {2, 2}},
                    3
                },
                new object[]
                {
                    new[] {new[] {0, 0}},
                    0
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Most_Stones_Removed_Tests(int[][] stones, int expected)
    {
        var result = new MostStonesRemoved().FromSameRowOrColumn(stones);
        result.Should().Be(expected);
    }
}