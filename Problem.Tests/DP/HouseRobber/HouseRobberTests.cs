using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class HouseRobberTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {1, 2, 3, 1},
                    4
                },
                new object[]
                {
                    new[] {2, 7, 9, 3, 1},
                    12
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void House_robber_tests(int[] data, int expected)
    {
        var result = new HouseRobber().Rob(data);
        result.Should().Be(expected);
    }
}