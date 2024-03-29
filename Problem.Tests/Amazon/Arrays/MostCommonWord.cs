﻿using System;
using System.Linq;
using FluentAssertions;

namespace Problem.Tests.Amazon.Arrays;

public class MostCommonWordTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "Bob hit a ball, the hit BALL flew far after it was hit.",
                    new[] {"hit"},
                    "ball"
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Most_common_word_tests(string paragraph, string[] banned, string expected)
    {
        var result = new MostCommonWord().Get(paragraph, banned);
        result.Should().Be(expected);
    }
}

public class MostCommonWord
{
    public string Get(string paragraph, string[] banned)
    {
        var bannedSet = new HashSet<string>(banned);
        var groups = paragraph
            .Replace("!", " ")
            .Replace("?", " ")
            .Replace("'", " ")
            .Replace(",", " ")
            .Replace(".", " ")
            .Replace(";", " ")
            .ToLower()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .GroupBy(w => w)
            .OrderByDescending(w => w.Count());

        foreach (var group in groups)
            if (!banned.Contains(group.Key))
                return group.Key;

        return string.Empty;
    }
}