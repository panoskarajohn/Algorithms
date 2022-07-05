using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class LongestIncreasingPathTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Longest_Increasing_Path_Tests(int[][] data, int expected)
    {
        var result = new LongestIncreasingPath().Get(data);
        result.Should().Be(expected);
    }
    
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Longest_Increasing_Path_DfsMem_Tests(int[][] data, int expected)
    {
        var result = new LongestIncreasingPath().GetDfsMemoization(data);
        result.Should().Be(expected);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {new[] {3, 4, 5}, new[] {3, 2,6}, new[] {2, 2,1}},
                    4
                },
                new object[]
                {
                    new[] {new[] {1}},
                    1
                },
            };
        }
    }
}