using System;
using FluentAssertions;

namespace Problem.Tests.Amazon.Arrays;

public class LongestConsecutiveTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Longest_consecutive_tests(int[] data, int exp)
    {
        var result = new LongestConsecutive().Longest(data);
        result.Should().Be(exp);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new int[] {100,4,200,1,3,2},
                    4
                }
            };
        }
    }
}

public class LongestConsecutive
{
    public int Longest(int[] nums) {
        
        var set = new HashSet<int>(nums);
        int max = 0;
        
        for(int i = 0; i < nums.Length; i++)
        {
            var current = nums[i];
            var isStart = !set.Contains(current - 1);
            if(isStart)
            {
                int length = 0;
                
                while(set.Contains(current + length))
                {
                    length++;
                }
                
                max = Math.Max(max, length);
            }
        }
        
        return max;
        
    }
}