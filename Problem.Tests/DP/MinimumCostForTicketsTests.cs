using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class MinimumCostForTicketsTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {1, 4, 6, 7, 8, 20},
                    new[] {2, 7, 15},
                    11
                },
                new object[]
                {
                    new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 30, 31},
                    new[] {2, 7, 15},
                    17
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Minimum_cost_for_tickets_tests(int[] days, int[] costs, int expected)
    {
        var result = new MinimumCostForTickets().MinCostTicketsTopDown(days, costs);
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Minimum_cost_for_tickets_Bottom_Up_tests(int[] days, int[] costs, int expected)
    {
        var result = new MinimumCostForTickets().MinCostTicketsBottomUp(days, costs);
        result.Should().Be(expected);
    }
}