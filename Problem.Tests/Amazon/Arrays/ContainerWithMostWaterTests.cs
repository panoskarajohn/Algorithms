using FluentAssertions;
using Problems.Amazon.Arrays;

namespace Problem.Tests.Amazon.Arrays;

public class ContainerWithMostWaterTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new [] { 1, 8, 6, 2, 5, 4, 8, 3, 7 },
                    49
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Container_with_most_water_tests(int[] heights, int expected)
    {
        var result = new ContainerWithMostWater().Get(heights);
        result.Should().Be(expected);
    }
}