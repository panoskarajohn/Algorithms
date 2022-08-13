using System.Linq;
using FluentAssertions;

namespace Problem.Tests.Amazon.Arrays;

public class RelativeOrderTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19},
                    new[] {2, 1, 4, 3, 9, 6},
                    new[] {2, 2, 2, 1, 4, 3, 3, 9, 6, 7, 19}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Relative_order_tests(int[] arr1, int[] arr2, int[] output)
    {
        var result = new RelativeOrder().RelativeSortArray(arr1, arr2);
        result.Should().BeEquivalentTo(output);
    }
}

public class RelativeOrder
{
    public int[] RelativeSortArray(int[] arr1, int[] arr2)
    {
        var count = new Dictionary<int, int>();
        var arr2Set = new HashSet<int>(arr2);
        var rest = new List<int>();

        foreach (var a in arr1)
            if (arr2Set.Contains(a))
            {
                if (count.ContainsKey(a))
                    count[a] += 1;
                else
                    count[a] = 1;
            }
            else
            {
                rest.Add(a);
            }

        var answer = new List<int>();
        foreach (var a in arr2)
            answer.AddRange(Enumerable.Repeat(a, count[a]));

        answer.AddRange(rest.OrderBy(a => a));
        return answer.ToArray();
    }
}