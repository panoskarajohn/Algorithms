using FluentAssertions;
using Problems.Google.Recursion;

namespace Problem.Tests.Google.Recursion;

public class ReverseStringTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[]
                    {
                        'h', 'e', 'l', 'l', 'o'
                    },
                    new[]
                    {
                        'o', 'l', 'l', 'e', 'h'
                    }
                },
                new object[]
                {
                    new[]
                    {
                        'H', 'a', 'n', 'n', 'a', 'h'
                    },
                    new[]
                    {
                        'h', 'a', 'n', 'n', 'a', 'H'
                    }
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Reverse_String_Tests(char[] word, char[] expected)
    {
        var rev = new ReverseString();
        rev.Reverse(word);
        var wordStr = new string(word);
        var expectedStr = new string(expected);
        wordStr.Should().Be(expectedStr);
    }
}