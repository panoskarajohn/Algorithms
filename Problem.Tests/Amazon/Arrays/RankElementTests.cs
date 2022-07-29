using FluentAssertions;
using Problems.Amazon.Arrays;

namespace Problem.Tests.Amazon.Arrays;

public class RankElementTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {40, 10, 20, 30},
                    new[] {4, 1, 2, 3}
                },
                new object[]
                {
                    new[] {100, 100, 100},
                    new[] {1, 1, 1}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Rank_element_tests(int[] data, int[] ex)
    {
        var r = new RankElements().Rank(data);
        r.Should().BeEquivalentTo(ex);
    }
}