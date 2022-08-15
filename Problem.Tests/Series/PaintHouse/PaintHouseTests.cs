using FluentAssertions;

namespace Problem.Tests.Series.PaintHouse;

public class PaintHouseTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Paint_house_tests(int[][] data, int expected)
    {
        var result = new Problems.Series.PaintHouse.PaintHouse().MinCost(data);
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
                    new[] {new[] {17, 2, 17}, new[] {16, 16, 5}, new[] {14, 3, 19}},
                    10
                },
                new object[]
                {
                    new[] {new[] {7, 6, 2}},
                    2
                },
            };
        }
    }
}