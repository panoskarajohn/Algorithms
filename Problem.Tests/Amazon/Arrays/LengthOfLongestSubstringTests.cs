using System.Collections.Generic;
using FluentAssertions;
using Problems.Amazon.Arrays;

namespace Problem.Tests.Amazon.Arrays;


public class LengthOfLongestSubstringTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Length_of_longest_substring_tests(string s, int expected)
    {
        var result = new LengthOfLongestSubstring().Get(s);
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
                    "abcabcbb", 
                    3
                }, 
                new object[]
                {
                    "pwwkew", 
                    3
                }
            };
        }
    }
}