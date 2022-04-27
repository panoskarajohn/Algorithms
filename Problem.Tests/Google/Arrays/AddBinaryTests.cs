using FluentAssertions;
using Problems.Google.Arrays;
using Problems.Google.String;
using Xunit;

namespace Problem.Tests.Google.Arrays;

public class AddBinaryTests
{
    [Theory]
    [InlineData("11", "1", "100")]
    [InlineData("1010", "1011", "10101")]
    [InlineData("111", "111", "1110")]
    public void Add_Binary_Tests(string bin1, string bin2, string expected)
    {
        var result = AddBinary.Add(bin1, bin2);
        result.Should().Be(expected);
    }
}