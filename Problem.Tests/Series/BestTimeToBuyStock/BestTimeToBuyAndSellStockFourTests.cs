using FluentAssertions;
using Problem.Tests.Google.DP;
using Problems.Series.BestTimeToBuyStock;

namespace Problem.Tests.Series.BestTimeToBuyStock;

public class BestTimeToBuyAndSellStockFourTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {2, 4, 1},
                    2,
                    2
                },
                new object[]
                {
                    new[] {3, 2, 6, 5, 0, 3},
                    2,
                    7
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Best_time_to_buy_and_sell_stock_four_top_down_tests(int[] prices, int k, int expected)
    {
        var result = new BestTimeToBuyAndSellStockFour().MaxProfitInKTransactionsTopDown(prices, k);
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Best_time_to_buy_and_sell_stock_four_bottom_up_tests(int[] prices, int k, int expected)
    {
        var result = new BestTimeToBuyAndSellStockFour().MaxProfitInKTransactionsBottomUp(prices, k);
        result.Should().Be(expected);
    }
}