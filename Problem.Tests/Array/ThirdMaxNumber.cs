using System;
using System.Linq;
using System.Threading.Tasks.Sources;
using FluentAssertions;

namespace Problem.Tests.Array;

public class ThirdMaxNumberTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Third_max_number_tests(int[] data, int expected)
    {
        var result = new ThirdMaxNumber().ThirdMax(data);
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
                    new int[] { 3,2,1 }, 
                    1
                },
                new object[]
                {
                    new int[] { 1,2 }, 
                    2
                },
                new object[]
                {
                    new int[] { 2,2,3,1 }, 
                    1
                },
                new object[]
                {
                    new int[] { 1,2,int.MinValue }, 
                    int.MinValue
                },
                
                new object[]
                {
                    new int[] { 1,int.MinValue, 2 }, 
                    int.MinValue
                },
            };
        }
    }
}

public class ThirdMaxNumber
{
    public int ThirdMax(int[] nums)
    {
        var set = new HashSet<int>(nums); // O(n)
        var max = set.Max();
        if (set.Count < 3)
            return max;

        set.Remove(max);
        max = set.Max();
        set.Remove(max);
        return set.Max();

        
    }
}