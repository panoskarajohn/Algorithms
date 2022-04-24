using FluentAssertions;
using Problems.Google;
using Xunit;

namespace Problem.Tests.Google;

public class LicenseKeyFormattingTests
{
    [Theory]
    [InlineData("5F3Z-2e-9-w", 4, "5F3Z-2E9W")]
    [InlineData("2-5g-3-J", 2, "2-5G-3J")]
    public void License_Key_Formatting_Tests(string s, int k, string expected)
    {
        string result = LicenseKeyFormatting.Execute(s, k);
        result.Should().Be(expected);
    }
}