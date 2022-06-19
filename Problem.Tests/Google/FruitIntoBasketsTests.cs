using FluentAssertions;
using Problems.Google;

namespace Problem.Tests.Google;

public class FruitIntoBasketsTests
{
    [Theory]
    [InlineData(new[] {1, 2, 1}, 3)]
    [InlineData(new[] {0, 1, 2, 2}, 3)]
    [InlineData(new[] {1, 2, 3, 2, 2}, 4)]
    [InlineData(new[] {3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4}, 5)]
    public void Fruit_Into_Baskets(int[] fruits, int expectedFruits)
    {
        var result = FruitsIntoBaskets.TotalFruit(fruits);
        result.Should().Be(expectedFruits);
    }
}