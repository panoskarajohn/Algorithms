using FluentAssertions;
using Problems.Google.DP;

namespace Problem.Tests.Google.DP;

public class MaximumProductSubarrayTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {2, 3, -2, 4},
                    6
                },
                new object[]
                {
                    new[] {-2, 0, -1},
                    0
                },
                new object[]
                {
                    new[] {-2, 3, -4},
                    24
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Maximum_Product_Subarray_Tests(int[] nums, int expected)
    {
        var result = new MaximumProductSubarray().MaxProduct(nums);
        result.Should().Be(expected);
    }
}