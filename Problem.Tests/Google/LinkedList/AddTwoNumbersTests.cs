using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.LinkedList;

namespace Problem.Tests.Google.LinkedList;

public class AddTwoNumbersTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    ListNodeExtensions.Create(2, 4, 3),
                    ListNodeExtensions.Create(5, 6, 4),
                    ListNodeExtensions.Create(7, 0, 8)
                },
                new object[]
                {
                    ListNodeExtensions.Create(0),
                    ListNodeExtensions.Create(0),
                    ListNodeExtensions.Create(0)
                },
                new object[]
                {
                    ListNodeExtensions.Create(9, 9, 9, 9),
                    ListNodeExtensions.Create(9, 9, 9, 9, 9, 9, 9),
                    ListNodeExtensions.Create(8, 9, 9, 9, 0, 0, 0, 1)
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Add_TwoNumbers_Tests(ListNode l1, ListNode l2, ListNode expected)
    {
        var result = AddTwoNumbers.Add(l1, l2);
        result.IsIdentical(expected)
            .Should()
            .BeTrue();
    }
}