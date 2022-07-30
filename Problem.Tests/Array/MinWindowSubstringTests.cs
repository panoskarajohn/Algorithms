using FluentAssertions;
using Problems.Amazon.Arrays;

namespace Problem.Tests.Array;

public class MinWindowSubstringTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Min_window_substring_tests(string s, string t, string expected)
    {
        var result = new MinWindowSubstring().Min(s, t);
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
                    "ADOBECODEBANC", 
                    "ABC", 
                    "BANC"
                },
            };
        }
    }
}