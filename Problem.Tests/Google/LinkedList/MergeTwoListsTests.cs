using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.LinkedList;
using Xunit;

namespace Problem.Tests.Google.LinkedList;

public class MergeTwoListsTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Merge_Two_Lists_Tests(ListNode listNodeOne, ListNode listNodeTwo, ListNode expected)
    {
        var result = MergeTwoLists.Merge(listNodeOne, listNodeTwo);
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
                    ListNodeExtensions.Create(1,2,4),
                    ListNodeExtensions.Create(1,3,4),
                    ListNodeExtensions.Create(1,1,2,3,4,4)
                }
            };
        }
    }
}