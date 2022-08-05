using System;
using System.Linq;
using FluentAssertions;

namespace Problem.Tests.Amazon.Arrays;

public class SynonymsTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new List<IList<string>>
                    {
                        new List<string>
                        {
                            "happy",
                            "joy"
                        },
                        new List<string>
                        {
                            "sad",
                            "sorrow"
                        },
                        new List<string>
                        {
                            "joy",
                            "cheerful"
                        }
                    },
                    "I am happy today but was sad yesterday",
                    new List<string>
                    {
                        "I am cheerful today but was sad yesterday", "I am cheerful today but was sorrow yesterday",
                        "I am happy today but was sad yesterday", "I am happy today but was sorrow yesterday",
                        "I am joy today but was sad yesterday", "I am joy today but was sorrow yesterday"
                    }
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Synonyms_tests(IList<IList<string>> synonyms, string text, IList<string> expected)
    {
        var result = new Synonyms().GenerateSentences(synonyms, text);
        result.Should().BeEquivalentTo(expected);
    }
}

public class Synonyms
{
    private readonly Dictionary<string, HashSet<string>> _graph = new();
    private readonly HashSet<string> _result = new HashSet<string>();

    public IList<string> GenerateSentences(IList<IList<string>> synonyms, string text)
    {
        BuildGraph(synonyms);
        var split = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        Dfs(split);
        
        var res = _result
            .ToList();
        res.Sort(Compare);
        return res;
    }

    void Dfs(string[] wordsFromSentence)
    {
        var newSentence = string.Join(" ", wordsFromSentence);
        if (_result.Contains(newSentence))
            return;

        _result.Add(newSentence);

        for (int i = 0; i < wordsFromSentence.Length; i++)
        {
            var wordToReplace = wordsFromSentence[i];
            if (!_graph.ContainsKey(wordToReplace))
                continue;

            var destinationWords = _graph[wordToReplace];
            foreach (var dest in destinationWords)
            {
                wordsFromSentence[i] = dest;
                Dfs(wordsFromSentence);
                wordsFromSentence[i] = wordToReplace;
            }
        }
    }

    void BuildGraph(IList<IList<string>> synonyms)
    {
        foreach (var synonym in synonyms)
        {
            if (!_graph.ContainsKey(synonym[0]))
            {
                _graph[synonym[0]] = new HashSet<string>();
            }
            
            if (!_graph.ContainsKey(synonym[1]))
            {
                _graph[synonym[1]] = new HashSet<string>();
            }

            
            _graph[synonym[0]].Add(synonym[1]);
            _graph[synonym[1]].Add(synonym[0]);
        }
    }

    static int Compare(string s1, string s2)
    {
        int length = Math.Min(s1.Length, s2.Length);

        for (int i = 0; i < length; i++)
        {
            if (s1[i] > s2[i])
                return 1;

            if (s1[i] < s2[i])
                return -1;
        }

        return 0;

    }
}