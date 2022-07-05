using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;
public class DecodeStringTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Decode_String_Tests(string s, string expected)
    {
        var result = new DecodeString().Decode(s);
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
                    "3[a]2[bc]",
                    "aaabcbc"
                },
                new object[]
                {
                    "3[a2[c]]",
                    "accaccacc"
                },
                new object[]
                {
                    "2[abc]3[cd]ef",
                    "abcabccdcdcdef"
                },

            };
        }
    }
}