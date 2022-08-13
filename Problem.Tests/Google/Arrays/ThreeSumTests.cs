using FluentAssertions;
using Problems.Google.Arrays;

namespace Problem.Tests.Google.Arrays;

public class ThreeSumTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    //[[-4,-2,6],[-4,0,4],[-4,1,3],[-4,2,2],[-2,-2,4],[-2,0,2]]
                    new[] {-4, -2, -2, -2, 0, 1, 2, 2, 2, 3, 3, 4, 4, 6, 6},
                    new List<List<int>>
                    {
                        new() {-4, -2, 6},
                        new() {-4, 0, 4},
                        new() {-4, 1, 3},
                        new() {-4, 2, 2},
                        new() {-2, -2, 4},
                        new() {-2, 0, 2}
                    }
                },
                new object[]
                {
                    new[] {-2, 0, 1, 1, 2},
                    new List<List<int>> {new() {-2, 0, 2}, new() {-2, 1, 1}}
                },
                new object[]
                {
                    new[] {-1, 0, 1, 0},
                    new List<List<int>> {new() {-1, 0, 1}}
                },
                new object[]
                {
                    new[] {0, 0, 0, 0},
                    new List<List<int>> {new() {0, 0, 0}}
                },
                new object[]
                {
                    new[] {-1, 0, 1, 2, -1, -4},
                    new List<List<int>> {new() {-1, -1, 2}, new() {-1, 0, 1}}
                },
                new object[]
                {
                    new int[] { },
                    new List<List<int>>()
                },
                new object[]
                {
                    new[] {0},
                    new List<List<int>>()
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Three_Sum_Tests(int[] input, List<List<int>> expected)
    {
        var result = ThreeSum.Execute(input);
        result.Should().BeEquivalentTo(expected);
    }
}