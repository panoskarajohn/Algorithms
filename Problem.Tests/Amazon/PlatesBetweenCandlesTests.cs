using System;
using System.Collections.Generic;
using FluentAssertions;
using Problems.Amazon;

namespace Problem.Tests.Amazon;

public class PlatesBetweenCandlesTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new Object[]
                {
                    "***|**|*****|**||**|*", 
                    new int[][]
                    {
                        new int[] {1,17},
                        new int[] {4,5},
                        new int[] {14,17},
                        new int[] {5,11},
                        new int[] {15,16},
                    },
                    new int[] {9,0,0,0,0}
                },
                new Object[]
                {
                    "**|**|***|", 
                    new int[][]
                    {
                        new int[] {2,5},
                        new int[] {5,9},
                    },
                    new int[] {2,3}
                },
                
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Plates_Between_Candles_Tests(string s, int[][] queries, int[] expected)
    {
        var result = new PlatesBetweenCandles().Count(s, queries);
        result.Should().BeEquivalentTo(expected);
    }
}