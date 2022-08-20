using FluentAssertions;
using Problems.PrefixSum;

namespace Problem.Tests.PrefixSum;

public class SubArrayEqualsKTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {1, 1, 1},
                    2,
                    2
                },
                new object[]
                {
                    new[] {1, 2, 3},
                    3,
                    2
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Sub_array_equals_k_tests(int[] data, int k, int expected)
    {
        var result = new SubArrayEqualsK().SubarraySum(data, k);
        result.Should().Be(expected);
    }
}