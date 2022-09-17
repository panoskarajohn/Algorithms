using FluentAssertions;
using Problems.DP.OneDimension;

namespace Problem.Tests.DP.OneDimension;

public class PalindromicSubstringsTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "abc", 3
                },
                new object[]
                {
                    "aaa", 6
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Palindromic_Substrings_Tests(string data, int expected)
    {
        var result = new PalindromicSubstrings().CountSubstrings(data);
        result.Should().Be(expected);
    }
}