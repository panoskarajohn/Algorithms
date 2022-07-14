using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.Recursion;

namespace Problem.Tests.Google.Recursion;


public class PascalTriangleTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Pascal_Triangle_Two_Tests(int input, IList<int> expected)
    {
        var result = new PascalTriangle()
            .GetRow(input);
        
        result
            .Should()
            .BeEquivalentTo(expected);
    }
    
    [Theory, MemberData(nameof(TestDataPropertyOne))]
    public void Pascal_Triangle_One_Tests(int input, IList<IList<int>> expected)
    {
        var result = new PascalTriangle()
            .GetRows(input);
        
        result
            .Should()
            .BeEquivalentTo(expected);
    }
    
    public static IEnumerable<object[]> TestDataPropertyOne
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    5,
                    new List<IList<int>>()
                    {
                        new List<int>() {1},
                        new List<int>() {1,1}, 
                        new List<int>() {1,2,1 }, 
                        new List<int>() {1, 3,3,1},
                        new List<int>() {1,4,6,4,1}
                    }
                },
                new object[]
                {
                    1,
                    new List<IList<int>> { new List<int>() {1}}
                },
                
            };
        }
    }
    
    
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    3,
                    new List<int>() {1,3,3,1}
                },
                new object[]
                {
                    0,
                    new List<int>() {1}
                },
                new object[]
                {
                    1,
                    new List<int>() {1, 1}
                },
            };
        }
    }
}