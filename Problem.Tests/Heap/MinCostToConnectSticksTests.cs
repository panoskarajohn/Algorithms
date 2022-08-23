using FluentAssertions;
using Problems.Heap;

namespace Problem.Tests.Heap;

public class MinCostToConnectSticksTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Min_cost_to_connect_sticks_tests(int[] sticks, int exp)
    {
        var result = new MinCostToConnectSticks().ConnectSticks(sticks);
        result.Should().Be(exp);

    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new int[] { 1,8,3,5 },
                    30
                },
                new object[]
                {
                    new int[] { 2,4,3 },
                    14
                },
            };
        }
    }
}