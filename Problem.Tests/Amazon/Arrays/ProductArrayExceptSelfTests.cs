using FluentAssertions;
using Problems.Amazon.Arrays;

namespace Problem.Tests.Amazon.Arrays;

public class ProductArrayExceptSelfTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {1, 2, 3, 4},
                    new[] {24, 12, 8, 6}
                },
                new object[]
                {
                    new[] {-1, 1, 0, -3, 3},
                    new[] {0, 0, 9, 0, 0}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Product_array_except_self_tests(int[] data, int[] expected)
    {
        var res = new ProductArray().GetExceptSelf(data);
        res.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Product_array_except_self_Optimized_tests(int[] data, int[] expected)
    {
        var res = new ProductArray().GetExceptSelfOptimized(data);
        res.Should().BeEquivalentTo(expected);
    }
}