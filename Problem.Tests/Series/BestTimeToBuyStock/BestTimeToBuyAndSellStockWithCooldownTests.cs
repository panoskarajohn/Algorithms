using FluentAssertions;
using Problems.DP;
using Problems.Series.BestTimeToBuyStock;

namespace Problem.Tests.Series.BestTimeToBuyStock;

public class BestTimeToBuyAndSellStockWithCooldownTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {1, 2, 3, 0, 2},
                    3
                },
                new object[]
                {
                    new[] {1},
                    0
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Best_time_to_buy_and_sell_stock_with_cooldown_tests(int[] data, int expected)
    {
        var result = new BestTimeToBuyAndSellStockWithCooldown().MaxProfitWithCooldown(data);
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Best_time_to_buy_and_sell_stock_with_cooldown_opt_tests(int[] data, int expected)
    {
        var result = new BestTimeToBuyAndSellStockWithCooldown().MaxProfitWithCooldownOpt(data);
        result.Should().Be(expected);
    }
}