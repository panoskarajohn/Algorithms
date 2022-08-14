using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class MaximumSumCircularSubarrayTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {1, -2, 3, -2},
                    3
                },
                new object[]
                {
                    new[] {5, -3, 5},
                    10
                },
                new object[]
                {
                    new[] {-3, -2, -3},
                    -2
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Maximum_sum_circular_subarray_tests(int[] data, int expected)
    {
        var result = new MaximumSubCircularSubArray().MaxSubarraySumCircular(data);
        result.Should().Be(expected);
    }
}