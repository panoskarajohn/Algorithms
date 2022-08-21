using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class InterleavingStringTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "aabcc",
                    "dbbca",
                    "aadbbcbcac",
                    true
                },
                new object[]
                {
                    "aabcc",
                    "dbbca",
                    "aadbbbaccc",
                    false
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Interleaving_string_tests(string s1, string s2, string s3, bool expected)
    {
        var result = new InterleavingString().IsInterleave(s1, s2, s3);
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Interleaving_string_Bottom_tests(string s1, string s2, string s3, bool expected)
    {
        var result = new InterleavingString().IsInterleaveBottomUp(s1, s2, s3);
        result.Should().Be(expected);
    }
}