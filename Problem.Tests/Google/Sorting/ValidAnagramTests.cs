using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.Sorting;

namespace Problem.Tests.Google.Sorting;

public class ValidAnagramTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "anagram",
                    "nagaram",
                    true
                },
                new object[]
                {
                    "rat",
                    "car",
                    false
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Valid_Anagram_Tests(string s, string t, bool expected)
    {
        var result = new ValidAnagram().IsAnagram(s, t);
        result.Should().Be(expected);
    }
}