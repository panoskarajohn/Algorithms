using System.Linq;
using FluentAssertions;

namespace Problem.Tests.Array;

public class GoodWordTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Good_word_tests(string[] words, string chars, int expected)
    {
        var result = new Goodword().CountCharacters(words, chars);
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
                    new string[] { "hello","world","leetcode" },
                    "welldonehoneyr",
                    10
                },
            };
        }
    }
}

public class Goodword
{
    public int CountCharacters(string[] words, string chars) {
        int sum = 0;
        foreach(var word in words)
        {
            if(!string.IsNullOrEmpty(word) && IsGood(word, chars))
                sum += word.Length;
        }
        return sum;
    }
    public bool IsGood(string s, string t)
    {
        var dic = new Dictionary<char, int>();
        for(int i = 0; i < s.Length; i++)
        {
            char current = s[i];
            if (!dic.ContainsKey(current))
                dic[current] = 0;
            dic[current]++;
        }
    
        
        for(int i = 0; i < t.Length; i++)
        {
            var current = t[i];
            if(!dic.ContainsKey(current) || dic[current] == 0)
                continue;
            dic[current]--;
        }
        
        return !dic.Any(n => n.Value != 0);
    }
}