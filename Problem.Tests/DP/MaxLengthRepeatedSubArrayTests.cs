using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class MaxLengthRepeatedSubArrayTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {1, 2, 3, 2, 1},
                    new[] {3, 2, 1, 4, 7},
                    3
                },
                new object[]
                {
                    new[] {0, 0, 0, 0, 0},
                    new[] {0, 0, 0, 0, 0},
                    5
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Max_length_repeated_sub_array_tests(int[] nums1, int[] nums2, int expected)
    {
        var result = new MaxLengthRepeatedSubArray()
            .FindLengthBottomUp(nums1, nums2);
        result.Should().Be(expected);
    }
}