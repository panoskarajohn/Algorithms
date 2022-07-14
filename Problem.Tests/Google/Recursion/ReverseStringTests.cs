using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Problems.Google.Recursion;

namespace Problem.Tests.Google.Recursion;


public class ReverseStringTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Reverse_String_Tests(char[] word, char[] expected)
    {
        var rev = new ReverseString();
        rev.Reverse(word);
        var wordStr = new string(word);
        var expectedStr = new string(expected);
        wordStr.Should().Be(expectedStr);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new char[]
                    {
                        'h', 'e', 'l', 'l', 'o',
                    },
                    new char[]
                    {
                        'o', 'l', 'l', 'e', 'h',
                    },
                },
                new object[]
                {
                    new char[]
                    {
                        'H','a','n','n','a','h'
                    },
                    new char[]
                    {
                        'h','a','n','n','a','H'
                    },
                },
            };
        }
    }
}