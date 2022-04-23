using System.Collections.Generic;
using FluentAssertions;
using Problems.Array;
using Problems.Google;
using Xunit;

namespace Problem.Tests.Google;

public class ThreeSumTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Three_Sum_Tests(int[] input, List<List<int>> expected)
    {
        var result = ThreeSum.Execute(input);
        result.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    //[[-4,-2,6],[-4,0,4],[-4,1,3],[-4,2,2],[-2,-2,4],[-2,0,2]]
                    new int[] { -4,-2,-2,-2,0,1,2,2,2,3,3,4,4,6,6 },
                    new List<List<int>>
                    {
                        new List<int>() {-4, -2, 6}, 
                        new List<int>() {-4, 0,  4},
                        new List<int>() {-4, 1,  3},
                        new List<int>() { -4, 2, 2},
                        new List<int>() { -2, -2 , 4}, 
                        new List<int>() { -2, 0, 2 }
                    }
                    
                },
                new object[]
                {
                    new int[] {-2, 0, 1, 1, 2},
                    new List<List<int>> {new List<int>() {-2, 0, 2}, new List<int>() {-2, 1, 1}}
                },
                new object[]
                {
                    new int[] {-1, 0, 1, 0},
                    new List<List<int>> {new List<int>() {-1, 0, 1}}
                },
                new object[]
                {
                    new int[] {0, 0, 0, 0},
                    new List<List<int>> {new List<int>() {0, 0, 0}}
                },
                new object[]
                {
                    new int[] {-1, 0, 1, 2, -1, -4},
                    new List<List<int>> {new List<int>() {-1, -1, 2}, new List<int>() {-1, 0, 1}}
                },
                new object[]
                {
                    new int[] { },
                    new List<List<int>> { }
                },
                new object[]
                {
                    new int[] {0},
                    new List<List<int>> { }
                },
            };
        }
    }
}