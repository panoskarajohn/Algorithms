using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.GraphsTrees;
using Xunit;

namespace Problem.Tests.Google.GraphsTrees;

public class SmallestStringWithSwapsTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Smallest_String_With_Swaps_Tests(string s, IList<IList<int>> pairs, string expected)
    {
        var result = SmallestStringWithSwaps.Get(s, pairs);
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
                    "dcab",
                    new List<IList<int>> {new List<int> {0, 3}, new List<int> {1, 2}},
                    "bacd"
                },
                new object[]
                {
                    "dcab",
                    new List<IList<int>> {new List<int> {0, 3}, new List<int> {1, 2}, new List<int> {0, 2}},
                    "abcd"
                },
                new object[]
                {
                    "cba",
                    new List<IList<int>> {new List<int> {0, 1}, new List<int> {1, 2}},
                    "abc"
                }
            };
        }
    }
}