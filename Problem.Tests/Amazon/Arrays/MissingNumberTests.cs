using FluentAssertions;
using Problems.Amazon.Arrays;

namespace Problem.Tests.Amazon.Arrays;

public class MissingNumberTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {3, 0, 1},
                    2
                },
                new object[]
                {
                    new[] {0, 1},
                    2
                },
                new object[]
                {
                    new[] {9, 6, 4, 2, 3, 5, 7, 0, 1},
                    8
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Missing_number_tests(int[] data, int expected)
    {
        var result = new MissingNumbers().Find(data);
        result.Should().Be(expected);
    }
}