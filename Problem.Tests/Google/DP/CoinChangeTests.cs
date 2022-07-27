using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.DP;

namespace Problem.Tests.Google.DP;

public class CoinChangeTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {1, 2, 5},
                    11,
                    3
                },
                new object[]
                {
                    new[] {2},
                    3,
                    -1
                },
                new object[]
                {
                    new[] {1},
                    0,
                    0
                }
            };
        }
    }
    
    public static IEnumerable<object[]> TestDataTwoProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {1, 2, 5},
                    5,
                    4
                },
                new object[]
                {
                    new[] {2},
                    3,
                    0
                },
                new object[]
                {
                    new[] {10},
                    10,
                    1
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Coin_Change_Tests(int[] coins, int amount, int expected)
    {
        var result = new CoinChange().Get(coins, amount);
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(TestDataTwoProperty))]
    public void Coin_Change_Two_Tests(int[] coins, int amount, int expected)
    {
        var result = new CoinChange().GetNumberOfCombinations(coins, amount);
        result.Should().Be(expected);
    }
}