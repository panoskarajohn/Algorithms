using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class NumberOfProvinceTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {new[] {1, 1, 0}, new[] {1, 1, 0}, new[] {0, 0, 1}},
                    2
                },
                new object[]
                {
                    new[] {new[] {1, 0, 0}, new[] {0, 1, 0}, new[] {0, 0, 1}},
                    3
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Number_Of_Province_Tests(int[][] isConnected, int expected)
    {
        var result = NumberOfProvinces.FindCircleNum(isConnected);
        result.Should().Be(expected);
    }
}