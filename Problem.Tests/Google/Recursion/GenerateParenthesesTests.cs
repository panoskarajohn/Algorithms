using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.Recursion;

namespace Problem.Tests.Google.Recursion;


public class GenerateParenthesesTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Generate_Parentheses_Tests(int n, IList<string> expected)
    {
        var result = new GenerateParentheses().Get(n);
        result.Should().BeEquivalentTo(expected);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    3,
                    new List<string> { "((()))","(()())","(())()","()(())","()()()" }
                },
                new object[]
                {
                    1,
                    new List<string> { "()" }
                },
            };
        }
    }
}