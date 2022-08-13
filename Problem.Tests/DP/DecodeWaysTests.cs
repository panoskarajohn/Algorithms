using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class DecodeWaysTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "12",
                    2
                },
                new object[]
                {
                    "226",
                    3
                },
                new object[]
                {
                    "06",
                    0
                },
                new object[]
                {
                    "10",
                    1
                },
                new object[]
                {
                    "27",
                    1
                },
                new object[]
                {
                    "2101",
                    1
                },
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Decode_ways_tests(string s, int expected)
    {
        var result = new DecodeWays().NumDecodings(s);
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Decode_ways_Bottom_Up_tests(string s, int expected)
    {
        var result = new DecodeWays().NumWaysDecodingBottomUp(s);
        result.Should().Be(expected);
    }
}