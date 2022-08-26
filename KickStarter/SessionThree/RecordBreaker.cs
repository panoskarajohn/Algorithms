using FluentAssertions;

namespace KickStarter.SessionThree;

public class RecordBreaker
{
    /// <summary>
    ///     Isyana is given the number of visitors at her local theme park on N consecutive days.
    ///     The number of visitors on the i-th day is Vi. A day is record breaking
    ///     if it satisfies both of the following conditions:
    ///     The number of visitors on the day is strictly larger than the number
    ///     of visitors on each of the previous days.
    ///     Either it is the last day, or the number of visitors on the day is strictly larger than the number of visitors on
    ///     the following day.
    ///     Note that the very first day could be a record breaking day!
    ///     Examples:
    ///     8
    ///     _   _
    ///     1 2 0 7 2 0 2 0 => 2
    ///     6
    ///     _
    ///     4 8 15 16 23 42 => 1
    ///     9
    ///     _   _     _
    ///     3 1 4 1 5 9 2 6 5 => 3
    ///     6
    ///     9 9 9 9 9 9 => 0
    /// </summary>
    public int GetWorldBreakingDay(int numOfDays, int[] visitors)
    {
        var anwer = 0;
        var max = int.MinValue;
        var count = new int[numOfDays];
        for (var i = 0; i < numOfDays; i++)
        {
            if (visitors[i] > max)
            {
                max = visitors[i];
                count[i]++;
            }

            if (i == numOfDays - 1)
                count[i]++;
            else if (visitors[i] > visitors[i + 1]) count[i]++;

            if (count[i] == 2) anwer++;
        }

        return anwer;
    }
}

public class RecordBreakerTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    8,
                    new[] {1, 2, 0, 7, 2, 0, 2, 0},
                    2
                },
                new object[]
                {
                    6,
                    new[] {4, 8, 15, 16, 23, 42},
                    1
                },
                new object[]
                {
                    9,
                    new[] {3, 1, 4, 1, 5, 9, 2, 6, 5},
                    3
                },
                new object[]
                {
                    6,
                    new[] {9, 9, 9, 9, 9, 9},
                    0
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Record_breaker_tests(int numberOfDays, int[] visitors, int expected)
    {
        var result = new RecordBreaker().GetWorldBreakingDay(numberOfDays, visitors);
        result.Should().Be(expected);
    }
}