using FluentAssertions;
using Problems.Google.DP;

namespace Problem.Tests.Google.DP;

public class BestTimeToBuyAndSellStockTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {7, 1, 5, 3, 6, 4},
                    5
                },
                new object[]
                {
                    new[] {7, 6, 4, 3, 1},
                    0
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Best_Time_To_Sell_And_Buy_Stock(int[] prices, int expected)
    {
        var result = new BestTimeToBuyAndSellStock().MaxProfit(prices);
        result.Should().Be(expected);
    }
}