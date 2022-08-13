using FluentAssertions;
using Problems.Amazon.Arrays;

namespace Problem.Tests.Array;

public class GroupAnagramsTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {"eat", "tea", "tan", "ate", "nat", "bat"},
                    new List<IList<string>>
                    {
                        new List<string> {"bat"},
                        new List<string> {"nat", "tan"},
                        new List<string> {"ate", "eat", "tea"}
                    }
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Group_anagrams_tests(string[] strs, IList<IList<string>> expected)
    {
        var result = new GroupAnagrams().Group(strs);
        result.Should().BeEquivalentTo(expected);
    }
}