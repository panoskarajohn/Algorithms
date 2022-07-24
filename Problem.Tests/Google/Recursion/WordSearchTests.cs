using System;
using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.Recursion;

namespace Problem.Tests.Google.Recursion;


public class WordSearchTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Word_search_tests(char[][] board, string word, bool expected)
    {
        var result = new WordSearch().Exists(board, word);
        result.Should().Be(expected);
    }

    [Theory, MemberData(nameof(TestDataTwoProperty))]
    public void Word_Search_Two_Slow_Tests(char[][] board, string[] words, string[] expected)
    {
        var result = new WordSearch().FindWords(board, words);
        result.Should().BeEquivalentTo(expected);
    }
    
    public static IEnumerable<object[]> TestDataTwoProperty
    {
        get
        {
            return new[]
            {
              new object[]
              {
                  new char[][]
                  {
                      new[] {'o', 'a', 'a', 'n'},
                      new[] {'e', 't', 'a', 'e'},
                      new[] {'i', 'h', 'k', 'r'},
                      new[] {'i', 'f', 'l', 'v'},
                  },
                  new string[] { "oath", "pea", "eat", "rain" }, 
                  new string[] { "eat", "oath" }
              }
            };
        }
    }

    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                  new char[][]
                  {
                      new[] { 'A' , 'B' },
                      new[] {'C', 'D'}
                  },
                  "ACDB",
                  true
                },
                new object[]
                {
                    new char[][]
                    {
                        new[] {'A'},

                    },
                    "A",
                    true
                    
                },
                new object[]
                {
                    new char[][]
                    {
                        new[] {'A', 'B', 'C', 'E'},
                        new[] {'S', 'F', 'C', 'S'},
                        new[] {'A', 'D', 'E', 'E'},
                    },
                    "ABCCED",
                    true
                    
                },
                new object[]
                {
                    new char[][]
                    {
                        new[] {'A', 'B', 'C', 'E'},
                        new[] {'S', 'F', 'C', 'S'},
                        new[] {'A', 'D', 'E', 'E'},
                    },
                    "SEE",
                    true
                },
                new object[]
                {
                    new char[][]
                    {
                        new[] {'A', 'B', 'C', 'E'},
                        new[] {'S', 'F', 'C', 'S'},
                        new[] {'A', 'D', 'E', 'E'},
                    },
                    "ABCB",
                    false
                },
                
            };
        }
    }
}