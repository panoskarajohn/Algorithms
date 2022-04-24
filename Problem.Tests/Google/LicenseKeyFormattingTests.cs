using FluentAssertions;
using Problems.Google;
using Xunit;

namespace Problem.Tests.Google;

public class LicenseKeyFormattingTests
{
    [Theory]
    [InlineData("5F3Z-2e-9-w", 4, "5F3Z-2E9W")]
    [InlineData("2-5g-3-J", 2, "2-5G-3J")]
    [InlineData("2-4A0r7-4k", 4,"24A0-R74K")]
    [InlineData("2-4A0r7-4k", 3,"24-A0R-74K")]
    [InlineData("r", 1,"R")]
    [InlineData("aaaa", 2,"AA-AA")]
    [InlineData("--a-a-a-a--", 2,"AA-AA")]
    [InlineData("a-----a", 2,"AA")]
    public void License_Key_Formatting_Tests(string s, int k, string expected)
    {
        string result = LicenseKeyFormatting.Execute(s, k);
        result.Should().Be(expected);
    }
}