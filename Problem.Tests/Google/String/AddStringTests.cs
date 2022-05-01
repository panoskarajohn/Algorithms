using FluentAssertions;
using Problems.Google.String;
using Xunit;

namespace Problem.Tests.Google.String;

public class AddStringTests
{
    [Theory]
    [InlineData("11", "123", "134")]
    [InlineData("456", "77", "533")]
    [InlineData("0", "0", "0")]
    public void Add_String_Tests(string num1, string num2, string expected)
    {
        var result = AddStrings.Add(num1, num2);
        result.Should().Be(expected);
    }
}