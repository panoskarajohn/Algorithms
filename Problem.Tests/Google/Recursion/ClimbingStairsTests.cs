using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.Recursion;

namespace Problem.Tests.Google.Recursion;



public class ClimbingStairsTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Climbing_stairs_Tests(int steps , int expected)
    {
        var result = new ClimbingStairs().Climb(steps);
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
                    1,
                    1
                },
                new object[]
                {
                    2,
                    2
                },
                new object[]
                {
                    3,
                    3
                }
            };
        }
    }
}