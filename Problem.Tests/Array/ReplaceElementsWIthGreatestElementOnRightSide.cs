using System;
using FluentAssertions;

namespace Problem.Tests.Array;

public class ReplaceElementsWIthGreatestElementOnRightSideTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {17, 18, 5, 4, 6, 1},
                    new[] {18, 6, 6, 6, 1, -1}
                },
                new object[]
                {
                    new[] {400},
                    new[] {-1}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Replace_elements_w_ith_greatest_element_on_right_side_tests(int[] data, int[] expected)
    {
        var result = new ReplaceElementsWIthGreatestElementOnRightSide().ReplaceElements(data);
        result.Should().BeEquivalentTo(expected);
        
    }
}

public class ReplaceElementsWIthGreatestElementOnRightSide
{
    public int[] ReplaceElements(int[] arr)
    {
        int n = arr.Length;
        int maxRight = arr[^1];
        arr[^1] = -1;
        
        for (int i = n - 2; i >= 0; i--)
        {
            var current = arr[i];
            arr[i] = maxRight;
            maxRight = Math.Max(maxRight, current);
        }

        return arr;
    }
}