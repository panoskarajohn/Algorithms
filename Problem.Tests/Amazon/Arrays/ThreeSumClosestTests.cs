using FluentAssertions;
using Problems.Amazon.Arrays;

namespace Problem.Tests.Amazon.Arrays;

public class ThreeSumClosestTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {-1, 2, 1, -4},
                    1,
                    2
                },
                new object[]
                {
                    new[] {0, 0, 0},
                    1,
                    0
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Three_sum_closest_tests(int[] data, int target, int expected)
    {
        var result = new ThreeSumClosest().Closest(data, target);
        result.Should().Be(expected);
    }
}