using FluentAssertions;
using Problems.Google.DP;

namespace Problem.Tests.Google.DP;

public class MaximumSubArrayTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {-2, 1, -3, 4, -1, 2, 1, -5, 4},
                    6
                },
                new object[]
                {
                    new[] {1},
                    1
                },
                new object[]
                {
                    new[] {5, 4, -1, 7, 8},
                    23
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Maximum_sub_array_tests(int[] nums, int expected)
    {
        var result = new MaximumSubarray().MaxSubArray(nums);
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Maximum_sub_array_2_tests(int[] nums, int expected)
    {
        var result = new MaximumSubarray().MaxSubArray2(nums);
        result.Should().Be(expected);
    }
}