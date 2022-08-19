using FluentAssertions;

namespace Problem.Tests.Array;

public class DuplicateZeros
{
    public void DupZeros(int[] arr)
    {
        var prev = 0;
        for (var i = 0; i < arr.Length; i++)
        {
            if (arr[i] != 0)
                continue;

            for (var j = i + 1; j < arr.Length; j++) (arr[j], prev) = (prev, arr[j]);

            i++;
            prev = 0;
        }
    }
}

public class DuplicateZerosTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {1, 0, 2, 3, 0, 4, 5, 0},
                    new[] {1, 0, 0, 2, 3, 0, 0, 4}
                },
                new object[]
                {
                    new[] {8, 5, 0, 9, 0, 3, 4, 7},
                    new[] {8, 5, 0, 0, 9, 0, 0, 3}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Duplicate_zeros_tests(int[] data, int[] expected)
    {
        var s = new DuplicateZeros();
        s.DupZeros(data);
        data.Should().BeEquivalentTo(expected);
    }
}