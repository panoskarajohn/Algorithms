using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.Recursion;

namespace Problem.Tests.Google.Recursion;


public class LetterCombinationsTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Letter_combinations_tests(string digits, IList<string> expected)
    {
        var combinations = new LetterCombinations().Get(digits);
        combinations.Should().BeEquivalentTo(expected);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "23",
                    new List<string> {"ad","ae","af","bd","be","bf","cd","ce","cf"} 
                },
                new object[]
                {
                    "2",
                    new List<string> { "a", "b", "c" }
                },
                new object[]
                {
                    "", 
                    new List<string> {}
                }
            };
        }
    }
}