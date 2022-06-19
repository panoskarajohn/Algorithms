using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class NumberOfComponentsUndirectedGraphTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    5,
                    new[] {new[] {0, 1}, new[] {1, 2}, new[] {3, 4}},
                    2
                },
                new object[]
                {
                    5,
                    new[] {new[] {0, 1}, new[] {1, 2}, new[] {2, 3}, new[] {3, 4}},
                    1
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Number_Of_Components_Cndirected_Graph_Tests(int n, int[][] edges, int expected)
    {
        var result = NumberOfComponentInAnUndirectedGraph.CountComponents(n, edges);
        result.Should().Be(expected);
    }
}