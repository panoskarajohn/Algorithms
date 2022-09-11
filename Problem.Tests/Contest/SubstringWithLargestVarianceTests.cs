using FluentAssertions;
using Problems.Contests;

namespace Problem.Tests.Contest;

public class SubstringWithLargestVarianceTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "aababbb",
                    3
                },
                new object[]
                {
                    "abcde",
                    0
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Substring_With_Largest_Variance_Tests(string s, int expected)
    {
        var result = new SubstringWithLargestVariance().LargestVariance(s);
        result.Should().Be(expected);
    }
}