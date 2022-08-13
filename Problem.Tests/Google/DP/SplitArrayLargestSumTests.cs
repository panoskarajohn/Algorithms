using FluentAssertions;
using Problems.Google.DP;

namespace Problem.Tests.Google.DP;

public class SplitArrayLargestSumTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {7, 2, 5, 10, 8},
                    2,
                    18
                },
                new object[]
                {
                    new[] {1, 2, 3, 4, 5},
                    2,
                    9
                },
                new object[]
                {
                    new[] {1, 4, 4},
                    3,
                    4
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Split_Array_Largest_Sum_Tests(int[] nums, int groups, int expected)
    {
        var result = new SplitArrayLargestSum().SplitArray(nums, groups);
        result.Should().Be(expected);
    }
}