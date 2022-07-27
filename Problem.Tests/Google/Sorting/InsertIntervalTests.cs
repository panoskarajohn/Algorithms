using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.Sorting;

namespace Problem.Tests.Google.Sorting;

public class InsertIntervalTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {new[] {1, 3}, new[] {6, 9}},
                    new[] {2, 5},
                    new[] {new[] {1, 5}, new[] {6, 9}}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Insert_Interval_Tests(int[][] intervals, int[] intervalToAdd, int[][] expected)
    {
        var result = new InsertInterval().Insert(intervals, intervalToAdd);
        result.Should().BeEquivalentTo(expected);
    }
}