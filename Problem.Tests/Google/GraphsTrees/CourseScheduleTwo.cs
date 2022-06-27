using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class CourseScheduleTwoTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Course_Schedule_Two_Tests(int numOfCourses, int[][] data, int[] expected)
    {
        var courseScheduleTwo = new CourseScheduleTwo().FindOrder(numOfCourses, data);
        courseScheduleTwo.Should().BeEquivalentTo(expected);
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
                    new[] {new[] {1, 0}},
                    new[] { 0,1 }
                },
                new object[]
                {
                    4,
                    new[] {new[] {1, 0}, new[] {2, 0}, new[] {3, 1}, new[] {3, 2}},
                    new[] { 0,2,1,3 }
                },
                new object[]
                {
                    1,
                    new int[][] {},
                    new[] { 0 }
                },
                
            };
        }
    }
}