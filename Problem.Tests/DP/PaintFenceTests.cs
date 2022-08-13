using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class PaintFenceTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    3, 2, 6
                },
                new object[]
                {
                    7, 2, 42
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Paint_fence_tests(int n, int k, int expected)
    {
        var result = new PaintFence().NumWays(n, k);
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Paint_fence_bottom_tests(int n, int k, int expected)
    {
        var result = new PaintFence().NumWaysBottomUp(n, k);
        result.Should().Be(expected);
    }
}