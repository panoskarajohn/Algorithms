using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class MinimumHeightTreesTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    4,
                    new[] {new[] {1, 0}, new[] {1, 2}, new[] {1, 3}},
                    new List<int> {1}
                },
                new object[]
                {
                    6,
                    new[] {new[] {3, 0}, new[] {3, 1}, new[] {3, 2}, new[] {3, 4}, new[] {5, 4}},
                    new List<int> {3, 4}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Minimum_Height_Trees_Tests(int n, int[][] edges, IList<int> expected)
    {
        var result = new MinimumHeightTrees().FindMinHeightTrees(n, edges);
        result.Should().BeEquivalentTo(expected);
    }
}