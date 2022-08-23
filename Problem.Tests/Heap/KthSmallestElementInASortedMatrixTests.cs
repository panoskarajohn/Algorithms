using FluentAssertions;
using Problems.Heap;

namespace Problem.Tests.Heap;


public class KthSmallestElementInASortedMatrixTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Kth_smallest_element_in_a_sorted_matrix_tests(int[][] data, int k, int exp)
    {
        var result = new KthSmallestElementInASortedMatrix().KthSmallest(data, k);
        result.Should().Be(exp);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {new[] {1, 5, 9}, new[] {10, 11, 13}, new[] {12, 13, 15}},
                    8,
                    13
                }
            };
        }
    }
}