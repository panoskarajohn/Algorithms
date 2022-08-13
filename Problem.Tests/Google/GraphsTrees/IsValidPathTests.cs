using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class IsValidPathTests
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
                    new[] {new[] {0, 1}, new[] {1, 2}, new[] {0, 2}},
                    0,
                    2,
                    true
                },
                new object[]
                {
                    6,
                    new[] {new[] {0, 1}, new[] {0, 2}, new[] {3, 5}, new[] {5, 4}, new[] {4, 3}},
                    0,
                    5,
                    false
                },
                new object[]
                {
                    1,
                    new[] {new int[] { }},
                    0,
                    0,
                    true
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Is_Valid_Path_Tests(int n, int[][] edges, int source, int destination, bool expected)
    {
        var validatePath = new ValidatePath();
        var actual = validatePath.IsValidPathUnionFind(n, edges, source, destination);
        actual.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Is_Valid_Path_Tests_Dfs(int n, int[][] edges, int source, int destination, bool expected)
    {
        var validatePath = new ValidatePath();
        var actual = validatePath.IsValidPathDfs(n, edges, source, destination);
        actual.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Is_Valid_Path_Tests_Bfs(int n, int[][] edges, int source, int destination, bool expected)
    {
        var validatePath = new ValidatePath();
        var actual = validatePath.IsValidPathBfs(n, edges, source, destination);
        actual.Should().Be(expected);
    }
}