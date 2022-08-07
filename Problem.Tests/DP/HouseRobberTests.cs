using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class HouseRobberTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void House_robber_tests(int[] data, int expected)
    {
        var result = new HouseRobber().Rob(data);
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
                    new int[] { 1,2,3,1 },
                    4
                },
                new object[]
                {
                    new int[] { 2,7,9,3,1 },
                    12
                },
            };
        }
    }
}