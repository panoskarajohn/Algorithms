using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.Recursion;

namespace Problem.Tests.Google.Recursion;


public class StrobogrammaticNumberTests
{
    [Theory, MemberData(nameof(NumberTests))]
    public void Strobogrammatic_Number_Tests(string input, bool expected)
    {
        var result = new StrobogrammaticNumber().IsStrobogrammatic(input);
        result.Should().Be(expected);
    }
    
    [Theory, MemberData(nameof(NumberTwoTests))]
    public void Strobogrammatic_Number_Two_Tests(int input, List<string> expected)
    {
        var result = new StrobogrammaticNumber().SlowFindStrobogrammatic(input);
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory, MemberData(nameof(NumberTwoTests))]
    public void Recursive_Strobogrammatic_Number_Two_Tests(int input, List<string> expected)
    {
        var result = new StrobogrammaticNumber().FindStrobogrammatic(input);
        result.Should().BeEquivalentTo(expected);
    }


    public static IEnumerable<object[]> NumberTests
    {
        get
        {
            return new[]
            {
                
                new object[]
                {
                    "1", 
                    true
                },
                new object[]
                {
                    "11", 
                    true
                },
                new object[]
                {
                    "118", 
                    false
                },
                new object[]
                {
                    "2",
                    false
                },
                new object[]
                {
                    "6",
                    false
                },
                new object[]
                {
                    "69",
                    true
                }, 
                new object[]
                {
                    "88",
                    true
                },
                new object[]
                {
                    "962",
                    false
                },
            };
        }
    }
    
    public static IEnumerable<object[]> NumberTwoTests
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    2,
                    new List<string>{"11", "69", "88", "96"},
                }, 
                new object[]
                {
                    1,
                    new List<string> {"0", "1", "8"}
                },
            };
        }
    }
}