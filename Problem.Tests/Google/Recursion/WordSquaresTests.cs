using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.Recursion;

namespace Problem.Tests.Google.Recursion;

public class WordSquaresTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Word_squares_tests(string[] words, IList<IList<string>> expected)
    {
        var result = new WordSquares().Get(words);
        //result.Should().BeEquivalentTo(expected);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new string[] { "area","lead","wall","lady","ball" }, 
                    new List<IList<string>> 
                    {
                        new List<string>() { "ball","area","lead","lady" },
                        new List<string>() { "wall","area","lead","lady" },
                    }
                },
                new object[]
                {
                    new string[] { "abat","baba","atan","atal" }, 
                    new List<IList<string>> 
                    {
                        new List<string>() { "baba","abat","baba","atal" },
                        new List<string>() { "baba","abat","baba","atan" },
                    }
                },
            };
        }
    }
}