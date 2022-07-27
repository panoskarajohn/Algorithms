using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.DP;

namespace Problem.Tests.Google.DP;

public class LongestPalindromicSubstringTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Longest_Palindromic_Substring_Tests(string s, string expected)
    {
        var result = new LongestPalindromicSubstring().Get(s);
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
                    "babad", 
                    "aba"
                },
                new object[]
                {
                    "cbbd", 
                    "bb"
                },
            };
        }
    }
}