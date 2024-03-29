﻿using FluentAssertions;
using Problems.Google.LinkedList;

namespace Problem.Tests.Google.LinkedList;

public class MergeKSortedListsTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new List<ListNode>
                    {
                        ListNodeExtensions.Create(1, 4, 5), ListNodeExtensions.Create(1, 3, 4),
                        ListNodeExtensions.Create(2, 6)
                    },
                    ListNodeExtensions.Create(1, 1, 2, 3, 4, 4, 5, 6)
                },
                new object[]
                {
                    new List<ListNode> {ListNodeExtensions.Create(1, 2, 2), ListNodeExtensions.Create(1, 1, 2)},
                    ListNodeExtensions.Create(1, 1, 1, 2, 2, 2)
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Merge_K_Sorted_Lists_Tests(ListNode[] lists, ListNode expected)
    {
        var result = new MergeKSortedLists().MergeKLists(lists);
        result
            .IsIdentical(expected)
            .Should()
            .BeTrue();
    }
}