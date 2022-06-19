using FluentAssertions;
using Problems.Google.LinkedList;

namespace Problem.Tests.Google.LinkedList;

public class ListNodeTests
{
    [Theory]
    [InlineData(new[] {1, 2, 3})]
    [InlineData(new[] {1, 2, 3, 4, 6, 10, 20, 32})]
    public void List_Node_Tests_Contain_The_Same_Values(int[] array)
    {
        var node = ListNodeExtensions.Create(array);
        var node2 = ListNodeExtensions.Create(array);

        var result = node.IsIdentical(node2);
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData(new[] {1, 2, 3}, new[] {1, 2, 3, 4})]
    [InlineData(new[] {1, 2, 3, 4, 6, 10, 20, 32, 43}, new[] {1, 2, 3, 4, 6, 10, 20, 32, 43, 32})]
    public void List_Node_Tests_Do_Not_Contain_The_Same_Values(int[] array, int[] array2)
    {
        var node = ListNodeExtensions.Create(array);
        var node2 = ListNodeExtensions.Create(array2);

        var result = node.IsIdentical(node2);
        result.Should().BeFalse();
    }
}