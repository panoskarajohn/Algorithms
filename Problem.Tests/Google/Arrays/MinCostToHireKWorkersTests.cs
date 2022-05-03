using FluentAssertions;
using Problems.Array;
using Xunit;

namespace Problem.Tests.Google.Arrays;

public class MinCostToHireKWorkersTests
{
    [Theory]
    [InlineData(new int[] { 10,20,5 }, new int[] { 70, 50, 30 }, 2, 105.00000)]
    [InlineData(new int[] { 3,1,10,10,1 }, new int[] { 4,8,2,2,7 }, 3, 30.66667)]
    public void Min_Cost_To_Hire_K_Workers_Tests(int[] quality, int[] wage, int k, double expected)
    {
        var result = MinCostToHIreKWorkers.MinCostToHireWorkers(quality, wage, k);
        result.Should().BeApproximately(expected, 0.10);
    }
}