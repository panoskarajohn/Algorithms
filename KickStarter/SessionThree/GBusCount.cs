using FluentAssertions;

namespace KickStarter.SessionThree;

public class GBusCount
{
    public int[] CountBuses(int[][] gBuses, int[] cities)
    {
        // sort on the first element
        var comparer = Comparer<int>.Default;
        Array.Sort(gBuses, (a, b)
            => comparer.Compare(a[1], b[1]));

        var result = new int[cities.Length];

        for (var i = 0; i < cities.Length; i++)
        {
            var city = cities[i];
            var indexToStart = BS(city, gBuses);
            var count = GetCountFromRange(indexToStart, gBuses, city);
            result[i] = count;
        }

        return result;
    }

    /// <summary>
    ///     Should return the most left element
    /// </summary>
    /// <param name="city"></param>
    /// <param name="gBuses"></param>
    /// <returns></returns>
    private int BS(int city, int[][] gBuses)
    {
        var left = 0;
        var right = gBuses.Length - 1;

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            var midElement = gBuses[mid];
            if (midElement[0] <= city && city <= midElement[1])
                right = mid;
            else if (midElement[0] > city)
                right = mid;
            else left = mid + 1;
        }

        return left;
    }

    private int GetCountFromRange(int indexToStart, int[][] gBuses, int city)
    {
        var count = 0;
        for (var i = indexToStart; i < gBuses.Length; i++)
        {
            var currentBus = gBuses[i];
            if (currentBus[0] <= city && city <= currentBus[1])
                count++;
            else
                break; // we can break here bc he binary searched the optimal left
        }

        return count;
    }
}

public class GBusCountTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {new[] {15, 25}, new[] {30, 35}, new[] {45, 50}, new[] {10, 20}},
                    new[] {15, 25},
                    new[] {2, 1}
                },
                new object[]
                {
                    new[]
                    {
                        new[] {10, 15}, new[] {5, 12}, new[] {40, 55}, new[] {1, 10}, new[] {25, 35},
                        new[] {45, 50}, new[] {20, 28}, new[] {27, 35}, new[] {15, 40}, new[] {4, 5}
                    },
                    new[] {5, 10, 27},
                    new[] {3, 3, 4}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void G_bus_count_tests(int[][] gBuses, int[] cities, int[] expected)
    {
        var result = new GBusCount().CountBuses(gBuses, cities);
        result.Should().BeEquivalentTo(expected);
    }
}