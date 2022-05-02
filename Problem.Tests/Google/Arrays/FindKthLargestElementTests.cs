using FluentAssertions;
using Problems.Google.Arrays;
using Xunit;

namespace Problem.Tests.Google.Arrays;

public class FindKthLargestElementTests
{
    [Theory]
    [InlineData(new int[] { 3,2,1,5,6,4 }, 2, 5)]
    [InlineData(new int[] { 3,2,3,1,2,4,5,5,6 }, 4, 4)]
    public void Find_Kth_Largest_Element_Tests(int[] nums, int k, int expected)
    {
        var result = FindKthLargestElement.Find(nums, k);
        result.Should().Be(expected);
    }
}