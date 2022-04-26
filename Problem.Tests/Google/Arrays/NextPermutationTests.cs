using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.Arrays;
using Xunit;

namespace Problem.Tests.Google.Arrays;

public class NextPermutationTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Next_Permutation_Tests(int[] nums, int[] expected)
    {
        NextPermutation.SetNext(nums);
        nums.Should().BeEquivalentTo(expected);

    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                  new int[] { 1,5,1},
                  new int[] { 5,1,1 }
                },
                new object[]
                {
                    new int[] { 1,2,3 },
                    new int[] { 1,3,2 }
                },
                new object[]
                {
                  new int[] { 3,2,1 },
                  new int[] { 1,2,3 }
                },
                new object[]
                {
                    new int[] { 1,1,5 },
                    new int[] { 1,5,1 }
                }
            };
        }
    }
}