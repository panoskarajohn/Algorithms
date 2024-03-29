﻿using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class EvaluateDivisionTests
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
                        new List<string> {"a", "b"},
                        new List<string> {"b", "c"}
                    },
                    new[] {2.0, 3.0},
                    new List<IList<string>>
                    {
                        new List<string> {"a", "c"},
                        new List<string> {"b", "a"},
                        new List<string> {"a", "e"},
                        new List<string> {"a", "a"},
                        new List<string> {"x", "x"}
                    },
                    new[] {6.00000, 0.50000, -1.00000, 1.00000, -1.00000}
                },
                new object[]
                {
                    new List<IList<string>>
                    {
                        new List<string> {"a", "b"},
                        new List<string> {"b", "c"},
                        new List<string> {"bc", "cd"}
                    },
                    new[] {1.5, 2.5, 5.0},
                    new List<IList<string>>
                    {
                        new List<string> {"a", "c"},
                        new List<string> {"c", "b"},
                        new List<string> {"bc", "cd"},
                        new List<string> {"cd", "bc"}
                    },
                    new[] {3.75000, 0.40000, 5.00000, 0.20000}
                },
                new object[]
                {
                    new List<IList<string>>
                    {
                        new List<string> {"a", "b"}
                    },
                    new[] {0.5},
                    new List<IList<string>>
                    {
                        new List<string> {"a", "b"},
                        new List<string> {"b", "a"},
                        new List<string> {"a", "c"},
                        new List<string> {"x", "y"}
                    },
                    new[] {0.50000, 2.00000, -1.00000, -1.00000}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Evaluate_Division_Tests(IList<IList<string>> equations, double[] values, IList<IList<string>> queries,
        double[] expected)
    {
        var result = EvaluateEquation.CalcEquation(equations, values, queries);
        result.Should().BeEquivalentTo(expected);
    }
}