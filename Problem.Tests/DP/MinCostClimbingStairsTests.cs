using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class MinCostClimbingStairsTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Min_cost_climbing_stairs_tests(int[] data, int expected)
    {
        var result = new MinCostClimbingStairs().Get(data);
        result.Should().Be(expected);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new int[] { 10,15,20 },
                    15
                },
                new object[]
                {
                    new int[] { 1,100,1,1,1,100,1,1,100,1 },
                    6
                },
            };
        }
    }
}