using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class NthTribonacciNumberTests
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
                    4
                },
                new object[]
                {
                    25,
                    1_389_537
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Nth_tribonacci_number_tests(int n, int expected)
    {
        var result = new NthTribonacciNumbers().Get(n);
        result.Should().Be(expected);
    }
}