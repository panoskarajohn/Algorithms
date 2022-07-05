using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class WordLadderTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Word_Ladder_Tests(string beginWord, string endWord, IList<string> wordList, int expected)
    {
        var result = new WordLadder().LadderLength(beginWord, endWord, wordList);
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
                    "hit",
                    "cog", 
                    new List<string> { "hot","dot","dog","lot","log","cog" },
                    5
                },
                new object[]
                {
                    "hit",
                    "cog", 
                    new List<string> { "hot","dot","dog","lot","log" },
                    0
                },
            };
        }
    }
}