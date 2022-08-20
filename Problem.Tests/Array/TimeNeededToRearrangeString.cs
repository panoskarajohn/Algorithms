using FluentAssertions;

namespace Problem.Tests.Array;

public class TimeNeededToRearrangeString
{
    public int SecondsToRemoveOccurrences(string s)
    {
        var seconds = 0;
        var sc = s.ToCharArray();
        var cont = false;
        var found = false;
        while (true)
        {
            for (var i = 0; i < s.Length - 1; i++)
                if (s[i] == '0' && s[i + 1] == '1')
                {
                    (sc[i], sc[i + 1]) = (sc[i + 1], sc[i]);
                    found = true;
                    i++;
                }

            if (found)
            {
                s = new string(sc);
                seconds++;
            }

            if (found)
            {
                found = false;
                continue;
            }

            break;
        }

        return seconds;
    }
}

public class TimeNeededToRearrangeStringTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "0110101",
                    4
                },
                new object[]
                {
                    "11100",
                    0
                },
                new object[]
                {
                    "001011",
                    4
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Time_needed_to_rearrange_string_tests(string s, int exp)
    {
        var result = new TimeNeededToRearrangeString().SecondsToRemoveOccurrences(s);
        result.Should().Be(exp);
    }
}