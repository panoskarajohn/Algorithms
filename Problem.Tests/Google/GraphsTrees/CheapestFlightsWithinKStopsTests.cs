using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class CheapestFlightsWithinKStopsTests
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
                    new[] {new[] {0, 1, 100}, new[] {1, 2, 100}, new[] {0, 2, 500}},
                    0,
                    2,
                    1,
                    200
                },
                new object[]
                {
                    3,
                    new[] {new[] {0, 1, 100}, new[] {1, 2, 100}, new[] {0, 2, 500}},
                    0,
                    2,
                    0,
                    500
                },
                new object[]
                {
                    4,
                    new[]
                    {
                        new[] {0, 1, 100}, new[] {1, 2, 100}, new[] {2, 0, 100}, new[] {1, 3, 600}, new[] {2, 3, 200}
                    },
                    0,
                    3,
                    1,
                    700
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Cheapest_Flights_Within_K_Stops_Tests(int n, int[][] flights, int src, int dst, int k, int expected)
    {
        var result = new CheapestFlightsWithinKStops().FindCheapestPrice(n, flights, src, dst, k);
        result.Should().Be(expected);
    }
}