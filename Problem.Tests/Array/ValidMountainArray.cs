using FluentAssertions;

namespace Problem.Tests.Array;

public class ValidMountainArrayTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {0, 3, 2, 1},
                    true
                },
                new object[]
                {
                    new[] {1, 3, 2},
                    true
                },
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Valid_mountain_array(int[] data, bool expected)
    {
        var result = new ValidMountainArray().IsValid(data);
        result.Should().Be(expected);
    }

    public class ValidMountainArray
    {
        public bool IsValid(int[] arr)
        {
            var n = arr.Length;
            if (n < 3) return false;
            var increased = false;
            var index = -1;

            for (var i = 0; i < n - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                    return false;

                if (arr[i] < arr[i + 1])
                    increased = true;

                if (arr[i] > arr[i + 1])
                {
                    index = i;
                    break;
                }
            }

            if (!increased || index == -1)
                return false;
            var decreased = false;
            for (var i = index; i < n - 1; i++)
            {
                if (arr[i] <= arr[i + 1])
                    return false;

                if (arr[i] > arr[i + 1]) decreased = true;
            }

            return true;
        }
    }
}