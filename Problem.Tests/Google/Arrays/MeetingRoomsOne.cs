using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.Arrays;
using Xunit;

namespace Problem.Tests.Google.Arrays;

public class MeetingRoomsTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Meeting_Rooms_One_Tests(int[][] array, bool expected)
    {
        var result = MeetingRooms.CanAttendMeetings(array);
        result.Should().Be(expected);
    }
    
    [Theory, MemberData(nameof(TestDataPropertyRooms))]
    public void Meeting_Rooms_Two_Tests(int[][] array, int expected)
    {
        var result = MeetingRooms.GetRooms(array);
        result.Should().Be(expected);
    }

    
    
    public static IEnumerable<object[]> TestDataPropertyRooms
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new [] { new []{ 2,11 } , new []{ 6,16 }, new []{ 11,16 }  }, 
                    2
                }, 
                new object[]
                {
                    new [] { new []{ 0,30 } , new []{ 5,10 }, new []{ 15,20 }  }, 
                    2
                }, 
                new object[]
                {
                    new [] { new[] { 7, 10}, new[] {2, 4} },
                    1
                }
            };
        }
    }

    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new [] { new []{ 0,30 } , new []{ 5,10 }, new []{ 15,20 }  }, 
                    false
                }, 
                new object[]
                {
                    new [] { new[] { 7, 10}, new[] {2, 4} },
                    true
                }
            };
        }
    }
}