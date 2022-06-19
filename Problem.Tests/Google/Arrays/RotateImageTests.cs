using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.Arrays;

namespace Problem.Tests.Google.Arrays;

public class RotateImageTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {new[] {1, 2, 3}, new[] {4, 5, 6}, new[] {7, 8, 9}},
                    new[] {new[] {7, 4, 1}, new[] {8, 5, 2}, new[] {9, 6, 3}}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Rotate_Image_Tests(int[][] rotate, int[][] expected)
    {
        RotateImage.RotateBrute(rotate);
        rotate.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Rotate_Image_No_Allocation_Tests(int[][] rotate, int[][] expected)
    {
        RotateImage.Rotate(rotate);
        rotate.Should().BeEquivalentTo(expected);
    }
}