using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class ParallelCoursesTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    3,
                    new[] {new[] {1, 3}, new[] {2, 3}},
                    2
                },
                new object[]
                {
                    3,
                    new[] {new[] {1, 2}, new[] {2, 3}, new[] {3, 1}},
                    -1
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Parallel_Courses_Tests(int n, int[][] relations, int expected)
    {
        var result = new ParallelCourses().MinNumberOfSemesters(n, relations);
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Parallel_Courses_Dfs_Tests(int n, int[][] relations, int expected)
    {
        var result = new ParallelCourses().MinNumberOfSemestersDfs(n, relations);
        result.Should().Be(expected);
    }
}