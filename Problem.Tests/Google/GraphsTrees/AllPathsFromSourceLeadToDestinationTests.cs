using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class AllPathsFromSourceLeadToDestinationTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    3,
                    new[] {new[] {0, 1}, new[] {0, 2}},
                    0,
                    2,
                    false
                },
                new object[]
                {
                    4,
                    new[] {new[] {0, 1}, new[] {0, 3}, new[] {1, 2}, new[] {0, 3}, new[] {2, 1}},
                    0,
                    3,
                    false
                },
                new object[]
                {
                    4,
                    new[] {new[] {0, 1}, new[] {0, 2}, new[] {1, 3}, new[] {2, 3}},
                    0,
                    3,
                    true
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void All_Paths_From_Source_Lead_To_Destination_Tests(int n, int[][] data, int source, int destination,
        bool expected)
    {
        var result = new AllPathsFromSourceLeadToDestination().AllLeadsToDestination(n, data, source, destination);
        result.Should().Be(expected);
    }
}