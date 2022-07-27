using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.Sorting;

namespace Problem.Tests.Google.Sorting;

public class CountOfSmallerNumbersAfterSelfTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Count_Of_Smaller_Numbers_After_Self_Tests(int[] input, List<int> expected)
    {
        var result = new CountOfSmallerNumberAfterSelf().Count(input);
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
                    new int[] { 5,2,6,1 }, 
                    new List<int> { 2,1,1,0 }
                },
                new object[]
                {
                    new int[] { -1 }, 
                    new List<int> { 0 }
                },
                new object[]
                {
                    new int[] { -1, -1 },
                    new List<int> { 0, 0}
                }
                
            };
        }
    }
}