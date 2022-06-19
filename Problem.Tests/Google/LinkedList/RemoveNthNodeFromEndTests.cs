using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.LinkedList;

namespace Problem.Tests.Google.LinkedList;

public class RemoveNthNodeFromEndTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    ListNodeExtensions.Create(1, 2, 3, 4, 5),
                    2,
                    ListNodeExtensions.Create(1, 2, 3, 5)
                },
                new object[]
                {
                    ListNodeExtensions.Create(1, 2),
                    1,
                    ListNodeExtensions.Create(1)
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void RemoveNthNodeTests(ListNode input, int n, ListNode expected)
    {
        var result = RemoveNthNodeFromEnd.Remove(input, n);
        result
            .IsIdentical(expected)
            .Should()
            .BeTrue();
    }
}