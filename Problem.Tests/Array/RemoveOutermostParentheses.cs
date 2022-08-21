using System.Linq;
using System.Text;
using FluentAssertions;

namespace Problem.Tests.Array;

public class RemoveOutermostParentheses
{
    public string RemoveOuterParentheses(string s)
    {
        var stack = new Stack<int>();
        var n = s.Length;
        var include = new bool[n];

        for (var i = 0; i < n; i++)
        {
            var current = s[i];
            if (current == '(')
            {
                stack.Push(i);
            }
            else
            {
                var start = stack.Pop();
                if (stack.Any())
                {
                    include[i] = true;
                    include[start] = true;
                }
            }
        }

        var sb = new StringBuilder();

        for (var i = 0; i < n; i++)
            if (include[i])
                sb.Append(s[i]);

        return sb.ToString();
    }
}

public class RemoveOutermostParenthesesTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "(()())(())",
                    "()()()"
                },
                new object[]
                {
                    "()()",
                    ""
                },
                new object[]
                {
                    "(()(()))()",
                    "()(())"
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Valid_parentheses_two_tests(string s, string expected)
    {
        var result = new RemoveOutermostParentheses().RemoveOuterParentheses(s);
        result.Should().Be(expected);
        result.Should().Be(expected);
    }
}