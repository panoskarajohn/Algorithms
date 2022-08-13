using FluentAssertions;
using Problems.Google.Sorting;

namespace Problem.Tests.Google.Sorting;

public class PeakIndexInAMountainArrayTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {0, 1, 0},
                    1
                },
                new object[]
                {
                    new[] {0, 2, 1, 0},
                    1
                },
                new object[]
                {
                    new[] {0, 10, 5, 2},
                    1
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Peak_Index_In_A_Mountain_Array_Tests(int[] data, int expected)
    {
        var result = new PeakIndexInAMountainArray().Get(data);
        result.Should().Be(expected);
    }
}