using System;
using FluentAssertions;

namespace Problem.Tests.Assessments;

public class WordPatternTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "abba",
                    "dog cat cat dog",
                    true
                },
                new object[]
                {
                    "abba",
                    "dog cat cat fish",
                    false
                },
                new object[]
                {
                    "aaaa",
                    "dog cat cat dog",
                    false
                },
                new object[]
                {
                    "aba",
                    "dog cat cat",
                    false
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Word_pattern_tests(string pattern, string s, bool expected)
    {
        var result = new WordPattern().Get(pattern, s);
        result.Should().Be(expected);
    }
}

public class WordPattern
{
    public bool Get(string pattern, string s)
    {
        var words = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        if (pattern.Length != words.Length)
            return false;

        var n = pattern.Length;

        var charMap = new char[26];
        var wordMap = new Dictionary<string, int>();

        for (var i = 0; i < n - 1; i++)
        {
            var currentChar = pattern[i] - 'a';
            var nextChar = pattern[i + 1] - 'a';
            var currentWord = words[i];
            var nextWord = words[i + 1];

            var charsEqual = currentChar == nextChar;
            var wordsEqual = currentWord == nextWord;


            //  we broke pattern
            // only this will not work for 
            // dog cat cat dog AND dog cat cat fish
            // since both dot not break pattern in equality
            if (charsEqual != wordsEqual)
                return false;

            // then we check if the words appear the same number of times
            charMap[currentChar]++;
            charMap[nextChar]++;
            if (!wordMap.ContainsKey(currentWord))
                wordMap[currentWord] = 0;
            if (!wordMap.ContainsKey(nextWord))
                wordMap[nextWord] = 0;

            wordMap[currentWord]++;
            wordMap[nextWord]++;

            var equalVisitation = charMap[currentChar] == wordMap[currentWord]
                                  && charMap[nextChar] == wordMap[nextWord];
            if (!equalVisitation)
                return false;
        }

        return true;
    }
}