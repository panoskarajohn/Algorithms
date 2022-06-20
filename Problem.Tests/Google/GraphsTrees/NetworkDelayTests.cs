using System.Collections.Generic;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class NetworkDelayTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Network_Delay_Dijkstra_Tests(int[][] data, int n, int k, int expected)
    {
        var networkDelay = new NetworkDelay();
        var result = networkDelay.NetworkDelayTime(data, n, k);
        Assert.Equal(expected, result);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {new[] {2, 1, 1}, new[] {2, 3, 1}, new[] {3, 4, 1}},
                    4,
                    2,
                    2
                },
                new object[]
                {
                    new[] {new[] {1, 2, 1}},
                    2,
                    1,
                    1
                },
                new object[]
                {
                    new[] {new[] {1, 2, 1}},
                    2,
                    2,
                    -1
                }
            };
        }
    }
}