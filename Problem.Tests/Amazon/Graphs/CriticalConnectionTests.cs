using System.Linq;
using FluentAssertions;
using Problems.Amazon.Graphs;

namespace Problem.Tests.Amazon.Graphs;

public class CriticalConnectionTests
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
                    new List<IList<int>>
                        {new List<int> {0, 1}, new List<int> {1, 2}, new List<int> {2, 0}, new List<int> {1, 3}},
                    new List<IList<int>> {new List<int> {1, 3}}
                },
                new object[]
                {
                    2,
                    new List<IList<int>>
                        {new List<int> {0, 1}},
                    new List<IList<int>> {new List<int> {0, 1}}
                },
                new object[]
                {
                    6,
                    new List<IList<int>>
                    {
                        new List<int> {0, 1},
                        new List<int> {1, 2},
                        new List<int> {2, 0},
                        new List<int> {1, 3},
                        new List<int> {3, 4},
                        new List<int> {4, 5},
                        new List<int> {5, 3}
                    },
                    new List<IList<int>> {new List<int> {1, 3}}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Critical_Connection_Tests(int n, IList<IList<int>> connections, IList<IList<int>> expected)
    {
        var result = new CriticalConnections().Get(n, connections);
        result = result.ToList();

        result
            .Should()
            .BeEquivalentTo(expected);
    }
}