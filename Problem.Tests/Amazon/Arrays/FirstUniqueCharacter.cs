using System.Linq;
using FluentAssertions;

namespace Problem.Tests.Amazon.Arrays;

public class FirstUniqueCharacter
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void First_unique_character(string s, int expected)
    {
        var result = new FirstUniqueChar().GetFirstIndex(s);
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
                    "leetcode",
                    0
                },
                new object[]
                {
                    "loveleetcode",
                    2
                },
                new object[]
                {
                    "aabb",
                    -1
                },
                
            };
        }
    }
}

public class FirstUniqueChar
{
    public int GetFirstIndex(string s)
    {
        var map = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            var current = s[i];
            if (!map.ContainsKey(current))
                map[current] = 0;
            map[current]++;
        }

        for (int i = 0; i < s.Length; i++)
        {
            var current = s[i];
            if (map[current] == 1)
                return i;
        }

        return -1;
    }
}