using FluentAssertions;
using Problems.Amazon.Arrays;

namespace Problem.Tests.Amazon.Arrays;

public class StringToIntegerTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "+1",
                    1
                },
                new object[]
                {
                    "+-12",
                    0
                },
                new object[]
                {
                    ".1",
                    0
                },
                new object[]
                {
                    "words and 987",
                    0
                },
                new object[]
                {
                    "42",
                    42
                },
                new object[]
                {
                    "      -42",
                    -42
                },
                new object[]
                {
                    "4193 with words",
                    4193
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void String_to_integer_tests(string s, int expected)
    {
        var result = new StringToInteger().MyAtoi(s);
        result.Should().Be(expected);
    }
}