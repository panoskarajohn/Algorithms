using FluentAssertions;
using Xunit;

namespace Problem.Tests.Array;

public class RemoveElementTests
{
    [Theory]
    [InlineData(new int[] {0, 1, 2, 2, 3, 0, 4, 2}, 5, 2)]
    public void Remove_Element_Tests(int[] array, int expectedReturn, int target)
    {
        var result = RemoveElement.Execute(array, target);
        result.Should().Be(expectedReturn);
    }
}