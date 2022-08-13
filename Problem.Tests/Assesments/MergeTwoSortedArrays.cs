using FluentAssertions;

namespace Problem.Tests.Assessments;

public class MergeTwoSortedArraysTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {4, 0, 0, 0, 0, 0},
                    1,
                    new[] {1, 2, 3, 5, 6},
                    5,
                    new[] {1, 2, 3, 4, 5, 6}
                },
                new object[]
                {
                    new[] {1, 2, 3, 0, 0, 0},
                    3,
                    new[] {2, 5, 6},
                    3,
                    new[] {1, 2, 2, 3, 5, 6}
                },
                new object[]
                {
                    new[] {4, 5, 6, 0, 0, 0},
                    3,
                    new[] {1, 2, 3},
                    3,
                    new[] {1, 2, 3, 4, 5, 6}
                },
                new object[]
                {
                    new[] {1},
                    1,
                    new int[] { },
                    0,
                    new[] {1}
                },
                new object[]
                {
                    new[] {0},
                    0,
                    new[] {1},
                    1,
                    new[] {1}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Merge_two_sorted_arrays(int[] data, int m, int[] data2, int n, int[] expected)
    {
        var s = new MergeTwoSortedArrays();
        s.Merge(data, m, data2, n);
        data.Should().BeInAscendingOrder();
        data.Should().BeEquivalentTo(expected);
    }
}

public class MergeTwoSortedArrays
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var rightOne = m - 1;
        var rightTwo = n - 1;

        for (var i = m + n - 1; i >= 0; i--)
            if (rightOne >= 0 && rightTwo >= 0)
                nums1[i] = nums1[rightOne] > nums2[rightTwo]
                    ? nums1[rightOne--]
                    : nums2[rightTwo--];
            else if (rightOne >= 0)
                nums1[i] = nums1[rightOne--];
            else
                nums1[i] = nums2[rightTwo--];
    }
}