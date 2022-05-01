using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.LinkedList;
using Xunit;

namespace Problem.Tests.LinkedList;

public class MergeKSortedListsTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Merge_K_Sorted_Lists_Tests(ListNode[] lists, ListNode expected)
    {
        var result = new MergeKSortedLists().MergeKLists(lists);
        result.IsIdentical(expected).Should().BeTrue();
    }

    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new List<ListNode> { ListNodeExtensions.Create(1,4,5), ListNodeExtensions.Create(1,3,4), ListNodeExtensions.Create(2,6) },
                    ListNodeExtensions.Create(1,1,2,3,4)
                }
            };
        }
    }

}