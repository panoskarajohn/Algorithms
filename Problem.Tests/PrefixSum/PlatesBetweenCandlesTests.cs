using FluentAssertions;
using Problems.Amazon;
using Problems.PrefixSum;

namespace Problem.Tests.PrefixSum;

public class PlatesBetweenCandlesTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "***|**|*****|**||**|*",
                    new[]
                    {
                        new[] {1, 17},
                        new[] {4, 5},
                        new[] {14, 17},
                        new[] {5, 11},
                        new[] {15, 16}
                    },
                    new[] {9, 0, 0, 0, 0}
                },
                new object[]
                {
                    "**|**|***|",
                    new[]
                    {
                        new[] {2, 5},
                        new[] {5, 9}
                    },
                    new[] {2, 3}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Plates_Between_Candles_Tests(string s, int[][] queries, int[] expected)
    {
        var result = new PlatesBetweenCandles().Count(s, queries);
        result.Should().BeEquivalentTo(expected);
    }
}