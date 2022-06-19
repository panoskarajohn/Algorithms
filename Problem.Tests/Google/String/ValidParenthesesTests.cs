using FluentAssertions;
using Problems.Google.String;

namespace Problem.Tests.Google.String;

public class ValidParenthesesTests
{
    [Theory]
    [InlineData("()", true)]
    [InlineData("()[]{}", true)]
    [InlineData("(]", false)]
    public void Valid_Parentheses_Tests(string s, bool expected)
    {
        var valid = new ValidParentheses().IsValid(s);
        valid.Should().Be(expected);
    }
}