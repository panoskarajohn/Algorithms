using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class AlienOrderTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {"wrt", "wrf", "er", "ett", "rftt"},
                    "wertf"
                },
                new object[]
                {
                    new[] {"z", "x"},
                    "zx"
                }
                //new object[] this is commented out as a reminder that this case has multiples solutions
                //{
                //    new[] { "z", "x", "z" },
                //    ""
                //},
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Alien_Order_Bfs_Tests(string[] words, string expected)
    {
        var result = new AlienDictionary().GetOrderBfs(words);
        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Alien_Order_Dfs_Tests(string[] words, string expected)
    {
        var result = new AlienDictionary().GetOrderDfs(words);
        result.Should().BeEquivalentTo(expected);
    }
}