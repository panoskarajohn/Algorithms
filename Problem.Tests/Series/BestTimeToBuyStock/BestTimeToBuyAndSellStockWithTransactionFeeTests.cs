using FluentAssertions;
using Problems.Series.BestTimeToBuyStock;

namespace Problem.Tests.Series.BestTimeToBuyStock;

public class BestTimeToBuyAndSellStockWithTransactionFeeTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {1, 3, 2, 8, 4, 9},
                    2,
                    8
                },
                new object[]
                {
                    new[] {1, 3, 7, 5, 10, 3},
                    3,
                    6
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Best_time_to_buy_and_sell_stock_with_transaction_fee_tests(int[] prices, int fee, int expected)
    {
        var result = new BestTimeToBuyAndSellStockWithTransactionFee().MaxProfitWithFee(prices, fee);
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Best_time_to_buy_and_sell_stock_with_transaction_fee_top_down_tests(int[] prices, int fee, int expected)
    {
        var result = new BestTimeToBuyAndSellStockWithTransactionFee().MatProfitWithFeeTopDown(prices, fee);
        result.Should().Be(expected);
    }
}