using Problems.Work;

namespace Problem.Tests.Work;

public class TreeProductTests
{
    [Theory]
    [InlineData(new int[] { 0, 1, 1, 3, 3, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 3, 5 }, 18)]
    public void Test1(int[] numsA, int[] numsB, int expected)
    {
        var actual = TreeProductSolution.TreeProduct(numsA, numsB);
        Assert.Equal(expected, actual);
    }
}