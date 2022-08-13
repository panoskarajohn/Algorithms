using FluentAssertions;
using Problems.Google.Sorting;

namespace Problem.Tests.Google.Sorting;

public class MedianOfTwoSortedArraysTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {1, 3},
                    new[] {2},
                    2.0000
                },
                new object[]
                {
                    new[] {1, 2},
                    new[] {3, 4},
                    2.50000
                },
                new object[]
                {
                    new[] {1, 2, 9, 10},
                    new[] {-1, 0, 0, 2},
                    1.50000
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Median_of_two_sorted_arrays_tests(int[] num1, int[] num2, double expected)
    {
        var result = new MedianOfTwoSortedArrays().FindMedian(num1, num2);
        result.Should().BeApproximately(expected, 0.10);
    }
}