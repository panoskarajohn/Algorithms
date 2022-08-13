using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class ValidTreeTests
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
                    new[] {new[] {0, 1}, new[] {0, 2}, new[] {0, 3}, new[] {1, 4}},
                    true
                },
                new object[]
                {
                    5,
                    new[] {new[] {0, 1}, new[] {1, 2}, new[] {2, 3}, new[] {1, 3}, new[] {1, 4}},
                    false
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Valid_Tree_Tests(int n, int[][] edges, bool expected)
    {
        var result = ValidTree.IsValid(n, edges);
        result.Should().Be(expected);
    }
}