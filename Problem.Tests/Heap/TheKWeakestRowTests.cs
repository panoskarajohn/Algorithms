using FluentAssertions;
using Problems.Heap;

namespace Problem.Tests.Heap;

public class TheKWeakestRowTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[]
                    {
                        new[] {1, 1, 0, 0, 0},
                        new[] {1, 1, 1, 1, 0},
                        new[] {1, 0, 0, 0, 0},
                        new[] {1, 1, 0, 0, 0},
                        new[] {1, 1, 1, 1, 1}
                    },
                    3,
                    new[] {2, 0, 3}
                },
                new object[]
                {
                    new[]
                    {
                        new[] {1, 0, 0, 0},
                        new[] {1, 1, 1, 1},
                        new[] {1, 0, 0, 0},
                        new[] {1, 0, 0, 0}
                    },
                    2,
                    new[] {0, 2}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void The_k_weakest_row_tests(int[][] data, int k, int[] expected)
    {
        var result = new FindKWeakestRow().KWeakestRows(data, k);
        result.Should().BeEquivalentTo(expected);
    }
}