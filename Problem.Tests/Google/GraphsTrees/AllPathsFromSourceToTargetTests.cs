using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class AllPathsFromSourceToTargetTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[]
                    {
                        new[] {4, 3, 1},
                        new[] {3, 2, 4},
                        new[] {3},
                        new[] {4},
                        new int[] { }
                    },
                    new List<IList<int>>
                    {
                        new List<int> {0, 4},
                        new List<int> {0, 3, 4},
                        new List<int> {0, 1, 3, 4},
                        new List<int> {0, 1, 2, 3, 4},
                        new List<int> {0, 1, 4}
                    }
                },
                new object[]
                {
                    new[]
                    {
                        new[] {1, 2},
                        new[] {3},
                        new[] {3},
                        new int[] { }
                    },
                    new List<IList<int>>
                    {
                        new List<int> {0, 1, 3},
                        new List<int> {0, 2, 3}
                    }
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void All_Paths_from_Source_To_Target_Tests(int[][] edges, IList<IList<int>> expected)
    {
        var actual = new AllPathsFromSourceToTarget().GetAllPaths(edges);
        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void All_Paths_from_Source_To_Target_Tests_Bfs(int[][] edges, IList<IList<int>> expected)
    {
        var actual = new AllPathsFromSourceToTarget().GetAllPaths2(edges);
        actual.Should().BeEquivalentTo(expected);
    }
}