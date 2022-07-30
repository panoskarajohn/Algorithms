using FluentAssertions;
using Problems.Amazon.Recursion;

namespace Problem.Tests.Amazon.Recursion;

public class NumberOfDiceRollsToTargetTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Number_of_dice_rolls_to_target_tests(int n, int k, int target, int expected)
    {
        var result = new NumberOfDiceRolls().NumRollsToTarget(n, k, target);
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
                    1, 6, 3, 1
                },
                new object[]
                {
                    2, 6, 7, 6
                },
                new object[]
                {
                    30, 30, 500, 222616187
                },
            };
        }
    }
}