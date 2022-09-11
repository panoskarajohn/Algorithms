using FluentAssertions;
using Problems.MonotonicQueue;

namespace Problem.Tests.MonoticQueue;

public class LongestContinuousSubarrayWithAbsoluteDiffLessOrEqualToLimitTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {8, 2, 4, 7},
                    4,
                    2
                },
                new object[]
                {
                    new[] {10, 1, 2, 4, 7, 2},
                    5,
                    4
                },
                new object[]
                {
                    new[] {4, 2, 2, 2, 4, 4, 2, 2},
                    0,
                    3
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Longest_Continuous_Subarray_With_Absolute_Diff_Less_Or_Equal_To_Limit_Tests(int[] nums, int limit,
        int expected)
    {
        var result = new LongestContinuousSubarrayWithAbsoluteDiffLessOrEqualToLimit()
            .LongestSubarray(nums, limit);
        result.Should().Be(expected);
    }
}