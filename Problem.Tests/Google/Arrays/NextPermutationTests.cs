using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.Arrays;

namespace Problem.Tests.Google.Arrays;

public class NextPermutationTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {1, 5, 1},
                    new[] {5, 1, 1}
                },
                new object[]
                {
                    new[] {1, 2, 3},
                    new[] {1, 3, 2}
                },
                new object[]
                {
                    new[] {3, 2, 1},
                    new[] {1, 2, 3}
                },
                new object[]
                {
                    new[] {1, 1, 5},
                    new[] {1, 5, 1}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Next_Permutation_Tests(int[] nums, int[] expected)
    {
        NextPermutation.SetNext(nums);
        nums.Should().BeEquivalentTo(expected);
    }
}