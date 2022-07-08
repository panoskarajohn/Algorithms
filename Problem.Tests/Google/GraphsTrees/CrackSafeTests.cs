using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class CrackSafeTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Crack_Safe_Tests(int n, int k, string expected)
    {
        var result = new CrackSafe().Crack(n, k);
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
                    1,2, "10"
                },
                new object[]
                {
                    2,2,"01100"
                },
            };
        }
    }
}