using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class NumberOfIslandsTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[]
                    {
                        new[] {'1', '1', '1', '1', '0'},
                        new[] {'1', '1', '0', '1', '0'},
                        new[] {'1', '1', '0', '0', '0'},
                        new[] {'0', '0', '0', '0', '0'}
                    },
                    1
                },
                new object[]
                {
                    new[]
                    {
                        new[] {'1', '1', '0', '0', '0'},
                        new[] {'1', '1', '0', '0', '0'},
                        new[] {'0', '0', '1', '0', '0'},
                        new[] {'0', '0', '0', '1', '1'}
                    },
                    3
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Number_Of_Islands_Tests(char[][] data, int expected)
    {
        var result = new NumberOfIslands().NumIslands(data);
        result.Should().Be(expected);
    }
}