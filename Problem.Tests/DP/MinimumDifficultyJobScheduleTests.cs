using FluentAssertions;
using Problems.DP;

namespace Problem.Tests.DP;

public class MinimumDifficultyJobScheduleTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {6, 5, 4, 3, 2, 1},
                    2,
                    7
                },
                new object[]
                {
                    new[] {9, 9, 9},
                    4,
                    -1
                },
                new object[]
                {
                    new[] {1, 1, 1},
                    3,
                    3
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Minimum_difficulty_job_schedule_tests_top_down(int[] data, int days, int expected)
    {
        var result = new MinimumDifficultyJobSchedule().MinDifficultyTopDown(data, days);
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Minimum_difficulty_job_schedule_tests_bottom_up(int[] data, int days, int expected)
    {
        var result = new MinimumDifficultyJobSchedule().MinDifficultyBottomUp(data, days);
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Minimum_difficulty_job_schedule_tests_bottom_up_opt(int[] data, int days, int expected)
    {
        var result = new MinimumDifficultyJobSchedule().MinDifficultyBottomUpOptimized(data, days);
        result.Should().Be(expected);
    }
}