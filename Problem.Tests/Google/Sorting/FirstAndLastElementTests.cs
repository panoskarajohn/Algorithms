using FluentAssertions;
using Problems.Google.Sorting;

namespace Problem.Tests.Google.Sorting;

public class FirstAndLastElementTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {5, 7, 7, 8, 8, 10},
                    8,
                    new[] {3, 4}
                },
                new object[]
                {
                    new[] {5, 7, 7, 8, 8, 10},
                    6,
                    new[] {-1, -1}
                },
                new object[]
                {
                    new int[] { },
                    0,
                    new[] {-1, -1}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void First_And_Last_Element_Tests(int[] nums, int target, int[] expected)
    {
        var result = new FirstAndLastElement().Find(nums, target);
        result.Should().BeEquivalentTo(expected);
    }
}