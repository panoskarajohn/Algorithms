using FluentAssertions;
using Problems.Google.Arrays;

namespace Problem.Tests.Google.Arrays;

public class KClosestPointToOriginTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {new[] {1, 3}, new[] {-2, 2}},
                    1,
                    new[] {new[] {-2, 2}}
                },
                new object[]
                {
                    new[] {new[] {3, 3}, new[] {5, -1}, new[] {-2, 4}},
                    2,
                    new[] {new[] {3, 3}, new[] {-2, 4}}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Closest_Point_To_Origin_Tests(int[][] points, int k, int[][] expected)
    {
        var result = KClosestPointsToOrigin.KClosest(k, points);
        result.Should().BeEquivalentTo(expected);
    }
}