using FluentAssertions;
using Problems.Series.PaintHouse;

namespace Problem.Tests.Series.PaintHouse;

public class PaintHouseTwoTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Paint_house_two_tests(int[][] data, int expected)
    {
        var result = new PaintHouseTwo().MinCost(data);
        result.Should().Be(expected);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    
                    new[] {new[] {1, 5, 3}, new[] {2, 9, 4}},
                    5
                },
                new object[]
                {
                    new[] {new[] {1, 3}, new[] { 2,4 }},
                    5
                },
            };
        }
    }
}