using System;
using FluentAssertions;

namespace Problem.Tests.Array;

public class MinRecolors
{
    public int MinimumRecolors(string blocks, int k)
    {
        if (k < 0)
            return 0;
        if (blocks.Length == 1 && k > 0)
            return blocks[0] == 'W' ? 1 : 0;

        var n = blocks.Length;
        var left = 0;
        var right = 0;
        var minOps = int.MaxValue;
        var numOps = 0;

        while (right < n)
        {
            if (blocks[right] == 'W') numOps++;

            if (right - left + 1 == k)
            {
                minOps = Math.Min(minOps, numOps);
                if (blocks[left] == 'W') numOps--;

                left++;
            }

            right++;
        }

        return minOps;
    }
}

public class MinRecolorsTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "W", 1, 1
                },
                new object[]
                {
                    "WBBWWBBWBW", 7, 3
                },
                new object[]
                {
                    "WBWBBBW", 2, 0
                },
                new object[]
                {
                    "WBB", 1, 0
                },
                new object[]
                {
                    "WBBWWWWBBWWBBBBWWBBWWBBBWWBBBWWWBWBWW", 15, 6
                },
                new object[]
                {
                    "WWBBBWBBBBBWWBWWWB", 16, 6
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Min_recolors_tests(string blocks, int k, int expected)
    {
        var result = new MinRecolors().MinimumRecolors(blocks, k);
        result.Should().Be(expected);
    }
}