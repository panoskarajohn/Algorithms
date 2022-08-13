using FluentAssertions;
using Problems.Amazon.Arrays;

namespace Problem.Tests.Amazon.Arrays;

public class CompareVersionNumbersTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "1.01",
                    "1.001",
                    0
                },
                new object[]
                {
                    "1.0",
                    "1.0.0",
                    0
                },
                new object[]
                {
                    "0.1",
                    "1.1",
                    -1
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Compare_version_numbers(string v1, string v2, int expected)
    {
        var result = new CompareVersionNumbers().CompareVersion(v1, v2);
        result.Should().Be(expected);
    }
}