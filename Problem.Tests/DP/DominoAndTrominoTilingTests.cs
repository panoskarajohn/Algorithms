using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class DominoAndTrominoTilingTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    3, 5
                },
                new object[]
                {
                    1, 1
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Domino_and_tromino_tiling_tests(int n, int expected)
    {
        var result = new DominoAndTrominoTiling().NumTilings(n);
        result.Should().Be(expected);
    }
}