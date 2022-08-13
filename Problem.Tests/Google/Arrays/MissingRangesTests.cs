using FluentAssertions;
using Problems.Google.Arrays;

namespace Problem.Tests.Google.Arrays;

public class MissingRangesTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {0, 1, 3, 50, 75},
                    0,
                    99,
                    new List<string> {"2", "4->49", "51->74", "76->99"}
                },
                new object[]
                {
                    new[] {-1},
                    -1,
                    -1,
                    new List<string>()
                },
                new object[]
                {
                    new[] {-1},
                    -2,
                    -1,
                    new List<string> {"-2"}
                },
                new object[]
                {
                    new[] {-1},
                    -2,
                    0,
                    new List<string> {"-2", "0"}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Missing_Ranges_Tests(int[] nums, int lower, int upper, List<string> expected)
    {
        var result = MissingRanges.GetNotOptimal(nums, lower, upper);
        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Missing_Ranges_Tests_Optimal(int[] nums, int lower, int upper, List<string> expected)
    {
        var result = MissingRanges.Get(nums, lower, upper);
        result.Should().BeEquivalentTo(expected);
    }
}