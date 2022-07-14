using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.Recursion;

namespace Problem.Tests.Google.Recursion;


public class FibonacciTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Fibonacci_tests(int input, int expected)
    {
        var result = new Fibonacci().Fib(input);
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
                   2,
                   1
                },
                new object[]
                {
                    3,
                    2
                },
                new object[]
                {
                    4,
                    3
                },
            };
        }
    }
}