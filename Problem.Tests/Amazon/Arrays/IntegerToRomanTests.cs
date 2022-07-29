using FluentAssertions;
using Problems.Amazon.Arrays;

namespace Problem.Tests.Amazon.Arrays;


public class IntegerToRomanTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Integer_to_roman_tests(int number, string expected)
    {
        var result = new IntegerToRoman().Convert(number);
        result.Should().Be(expected);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    3,
                    "III"
                },
                new object[]
                {
                    58, 
                    "LVIII"
                },
                new object[]
                {
                    1994, 
                    "MCMXCIV"
                }
            };
        }
    }
}