using FluentAssertions;
using Problems.MonotonicQueue;

namespace Problem.Tests.MonoticQueue;

public class MaximumNumbersOfRobotsWithinBudgetsTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {3, 6, 1, 3, 4},
                    new[] {2, 1, 3, 4, 5},
                    25,
                    3
                },
                new object[]
                {
                    new[] {11, 12, 19},
                    new[] {10, 8, 7},
                    19,
                    0
                },
                new object[]
                {
                    new[] {11, 12, 74, 67, 37, 87, 42, 34, 18, 90, 36, 28, 34, 20},
                    new[] {18, 98, 2, 84, 7, 57, 54, 65, 59, 91, 7, 23, 94, 20},
                    937,
                    4
                },
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Maximum_Numbers_Of_Robots_Within_Bufdgets_Tests(int[] chargeTime,
        int[] runningCosts, int budget, int expected)
    {
        var result = new MaximumNumbersOfRobotsWithinBudgets()
            .MaximumRobots(chargeTime, runningCosts, budget);
        result.Should().Be(expected);
    }
}