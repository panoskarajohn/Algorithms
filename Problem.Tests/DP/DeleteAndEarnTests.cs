﻿using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class DeleteAndEarnTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {3, 4, 2},
                    6
                },
                new object[]
                {
                    new[] {2, 2, 3, 3, 3, 4},
                    9
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Delete_and_earn_tests(int[] nums, int expected)
    {
        var result = new DeleteAndEarn().Do(nums);
        result.Should().Be(expected);
    }
}