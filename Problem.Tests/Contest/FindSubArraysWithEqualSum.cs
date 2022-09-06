using FluentAssertions;

namespace Problem.Tests.Contest;

public class FindSubArraysWithEqualSum
{
    public bool FindSubarrays(int[] nums)
    {
        var n = nums.Length;
        var map = new Dictionary<int, int>();

        for (var i = 0; i < n - 1; i++)
        {
            var sum = nums[i] + nums[i + 1];
            if (!map.ContainsKey(sum))
                map[sum] = 0;
            map[sum]++;

            if (map[sum] >= 2)
                return true;
        }

        return false;
    }
}

public class FindSubArraysWithEqualSumTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {4, 2, 4},
                    true
                },
                new object[]
                {
                    new[] {1, 2, 3, 4, 5},
                    false
                },
                new object[]
                {
                    new[] {0, 0, 0},
                    true
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Find_sub_arrays_with_equal_sum_tests(int[] data, bool expected)
    {
        var result = new FindSubArraysWithEqualSum().FindSubarrays(data);
        result.Should().Be(expected);
    }
}