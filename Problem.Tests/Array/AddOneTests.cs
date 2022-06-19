using FluentAssertions;
using Problems.Array;

namespace Problem.Tests.Array;

public class AddOneTests
{
    [Theory]
    [InlineData(new[] {1, 2, 3}, new[] {1, 2, 4})]
    [InlineData(new[] {9}, new[] {1, 0})]
    [InlineData(new[] {9, 8, 9}, new[] {9, 9, 0})]
    [InlineData(new[] {9, 8, 7, 6, 5, 4, 3, 2, 1, 0}, new[] {9, 8, 7, 6, 5, 4, 3, 2, 1, 1})]
    [InlineData(
        new[]
        {
            7, 2, 8, 5, 0, 9, 1, 2, 9, 5, 3, 6, 6, 7, 3, 2, 8, 4, 3, 7, 9, 5, 7, 7, 4, 7, 4, 9, 4, 7, 0, 1, 1, 1, 7, 4,
            0, 0, 6
        },
        new[]
        {
            7, 2, 8, 5, 0, 9, 1, 2, 9, 5, 3, 6, 6, 7, 3, 2, 8, 4, 3, 7, 9, 5, 7, 7, 4, 7, 4, 9, 4, 7, 0, 1, 1, 1, 7, 4,
            0, 0, 7
        })]
    public void Add_One_Tests(int[] input, int[] expected)
    {
        var result = AddOne.Execute(input);
        result.Should().BeEquivalentTo(expected);
    }
}