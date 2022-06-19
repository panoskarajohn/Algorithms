using FluentAssertions;
using Problems.Array;

namespace Problem.Tests.Array;

public class SearchInsertPositionTests
{
    [Theory]
    [InlineData(new[] {1, 3, 5, 6}, 5, 2)]
    [InlineData(new[] {1, 3, 5, 6}, 2, 1)]
    [InlineData(new[] {1, 3, 5, 6}, 7, 4)]
    [InlineData(new[] {1, 3, 5, 6}, 0, 0)]
    [InlineData(new[] {1, 3, 5}, 1, 0)]
    [InlineData(new[] {1, 2, 3, 4, 5, 10}, 2, 1)]
    [InlineData(new[] {1}, 0, 0)]
    [InlineData(new[] {1}, 2, 1)]
    [InlineData(new[] {1, 3}, 0, 0)]
    public void Search_Insert_Position_Tests(int[] array, int target, int expectedIndex)
    {
        var result = SearchInsertPosition.Execute(array, target);
        result.Should().Be(expectedIndex);
    }
}