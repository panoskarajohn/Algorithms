using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class CountVowelsTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    1, 5
                },
                new object[]
                {
                    2, 10
                },
                new object[]
                {
                    5, 68
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Count_vowels_tests(int n, int expected)
    {
        var result = new CountVowels().CountVowelPermutation(n);
        result.Should().Be(expected);
    }
}