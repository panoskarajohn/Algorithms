using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.Recursion;

namespace Problem.Tests.Google.Recursion;

public class AndroidUnlockPatternTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    1, 1, 9
                },
                new object[]
                {
                    1, 2, 65
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Android_Unlock_Pattern_Tests(int m, int n, int expected)
    {
        var result = new AndroidUnlockPatterns().NumberOfPatterns(m, n);
        result.Should().Be(expected);
    }
}