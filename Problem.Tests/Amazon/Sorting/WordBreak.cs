using FluentAssertions;

namespace Problem.Tests.Amazon.Sorting;

public class WordBreakTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "leetcode",
                    new List<string> {"leet", "code"},
                    true
                },
                new object[]
                {
                    "catsandog",
                    new[] {"cats", "dog", "sand", "and", "cat"},
                    false
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Word_break_tests(string s, IList<string> words, bool expected)
    {
        var result = new WordBreak().AreWordsSegmentsOf(s, words);
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Word_break_tests_bottom_up(string s, IList<string> words, bool expected)
    {
        var result = new WordBreak().AreWordsSegmentsOfDpBottomUp(s, words);
        result.Should().Be(expected);
    }
}

public class WordBreak
{
    public bool AreWordsSegmentsOf(string s, IList<string> wordDict)
    {
        return WordBreakHelper(s, new HashSet<string>(wordDict), 0, new bool?[s.Length]);
    }

    private bool WordBreakHelper(string s, HashSet<string> wordDict, int start, bool?[] memo)
    {
        if (start == s.Length)
            return true;

        if (memo[start] is { })
            return memo[start]!.Value;

        for (var end = start + 1; end <= s.Length; end++)
            if (wordDict.Contains(s[start..end]) && WordBreakHelper(s, wordDict, end, memo))
            {
                memo[start] = true;
                return true;
            }

        memo[start] = false;
        return false;
    }

    public bool AreWordsSegmentsOfDpBottomUp(string s, IList<string> wordDict)
    {
        var n = s.Length;
        var dp = new bool[n];

        for (var i = 0; i < n; i++)
            foreach (var word in wordDict)
                if (i >= word.Length - 1 && (i == word.Length - 1 || dp[i - word.Length]))
                    if (s[(i - word.Length + 1)..(i + 1)] == word)
                    {
                        dp[i] = true;
                        break;
                    }

        return dp[n - 1];
    }
}