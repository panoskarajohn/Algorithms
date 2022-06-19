using FluentAssertions;
using Problems.Google.String;

namespace Problem.Tests.Google.String;

public class MultiplyStringsTests
{
    [Theory]
    [InlineData("2", "3", "6")]
    [InlineData("123", "456", "56088")]
    public void Multiply_Strings_Tests(string num1, string num2, string expected)
    {
        var result = MultiplyStrings.Multiply(num1, num2);
        result.Should().Be(expected);
    }
}