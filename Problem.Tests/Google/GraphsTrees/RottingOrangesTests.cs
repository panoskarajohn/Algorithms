using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class RottingOrangesTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {new[] {2, 1, 1}, new[] {1, 1, 0}, new[] {0, 1, 1}},
                    4
                },
                new object[]
                {
                    new[] {new[] {2, 1, 1}, new[] {0, 1, 1}, new[] {1, 0, 1}},
                    -1
                },
                new object[]
                {
                    new[] {new[] {0, 2}},
                    0
                },
                new object[]
                {
                    new[] {new[] {1}},
                    -1
                },
                new object[]
                {
                    new[] {new[] {1, 2, 2}},
                    1
                },
                new object[]
                {
                    new[] {new[] {0}},
                    0
                },
                new object[]
                {
                    new[] {new[] {2, 1, 1}, new[] {1, 1, 1}, new[] {0, 1, 2}},
                    2
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Rotting_Oranges_Tests(int[][] data, int expected)
    {
        var result = new RottingOranges().OrangesRotting(data);
        Assert.Equal(expected, result);
    }
}