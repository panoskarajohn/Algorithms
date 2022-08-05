using FluentAssertions;

namespace Problem.Tests.Amazon.Sorting;

public class SearchInRotatedSortedArrayTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {4, 5, 6, 7, 0, 1, 2},
                    0,
                    4
                },
                new object[]
                {
                    new[] {4, 5, 6, 7, 0, 1, 2},
                    3,
                    -1
                },
                new object[]
                {
                    new[] {1},
                    0,
                    -1
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Search_in_rotated_sorted_array_tests(int[] data, int target, int expectedIndex)
    {
        var result = new SearchInRotatedSortedArray().Search(data, target);
        result.Should().Be(expectedIndex);
    }
}

public class SearchInRotatedSortedArray
{
    public int Search(int[] nums, int target)
    {
        
        return BinarySearchInRotatedSortedArray(nums, target);
    }

    private int BinarySearchInRotatedSortedArray(int[] nums, int target)
    {
        int n = nums.Length;
        if (n == 0)
            return -1;
        
        int left = 0;
        int right = n - 1;
        int first = nums[0];

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int value = nums[mid];

            if (value == target)
                return mid;

            if (value >= first == target >= first)
            {
                if (value < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            else
            {
                if (value >= first)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            
        }

        return -1;
    }
}