using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.Sorting;

namespace Problem.Tests.Google.Sorting;

public class MergeIntervalsTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {new[] {0, 4}, new[] {3, 5}},
                    new[] {new[] {0, 5}}
                },
                new object[]
                {
                    new[] {new[] {1, 4}, new[] {2, 3}},
                    new[] {new[] {1, 4}}
                },
                new object[]
                {
                    new[] {new[] {1, 3}, new[] {2, 6}, new[] {8, 10}, new[] {15, 18}},
                    new[] {new[] {1, 6}, new[] {8, 10}, new[] {15, 18}}
                },
                new object[]
                {
                    new[] {new[] {1, 4}, new[] {0, 2}, new[] {3, 5}},
                    new[] {new[] {0, 5}}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Merge_Intervals_Tests(int[][] intervals, int[][] expected)
    {
        var result = new MergeIntervals().Merge(intervals);
        result.Should().BeEquivalentTo(expected);
    }
}