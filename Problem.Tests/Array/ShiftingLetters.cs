using System.Text;
using FluentAssertions;

namespace Problem.Tests.Array;

public class ShiftingLetters
{
    /// <summary>
    ///     Non optimal but mine
    /// </summary>
    /// <param name="s"></param>
    /// <param name="shifts"></param>
    /// <returns></returns>
    public string Shift(string s, int[][] shifts)
    {
        var sc = s.ToCharArray();
        var dictionary = new Dictionary<(int start, int end), string>();
        foreach (var shift in shifts)
        {
            var isBackward = shift[2] == 0;
            if (isBackward)
                for (var i = shift[0]; i <= shift[1]; i++)
                {
                    var gotoNum = (sc[i] - 'a' - 1) % 26;
                    var goTo = gotoNum < 0 ? 26 + gotoNum : gotoNum;
                    var toGo = (char) (97 + goTo);
                    sc[i] = toGo;
                }
            else
                for (var i = shift[0]; i <= shift[1]; i++)
                {
                    var gotoNum = (sc[i] - 'a' + 1) % 26;
                    var goTo = gotoNum < 0 ? 26 + gotoNum : gotoNum;
                    var toGo = (char) (goTo + 97);
                    sc[i] = toGo;
                }
        }

        return new string(sc);
    }

    /// <summary>
    ///     Line sweep algorithm
    /// </summary>
    /// <param name="s"></param>
    /// <param name="shifts"></param>
    /// <returns></returns>
    public string ShiftOptimal(string s, int[][] shifts)
    {
        var n = s.Length;
        var delta = new int[n + 1];

        foreach (var shift in shifts)
        {
            var start = shift[0];
            var end = shift[1];
            var direction = shift[2];

            if (direction == 1)
            {
                delta[start]++;
                delta[end + 1]--;
            }
            else
            {
                delta[start]--;
                delta[end + 1]++;
            }
        }

        for (var i = 1; i < n; i++) delta[i] += delta[i - 1];

        var answer = new StringBuilder();

        for (var i = 0; i < n; i++)
        {
            var current = (s[i] - 'a' + delta[i]) % 26;
            var goTo = current < 0 ? 26 + current : current;
            answer.Append((char) (goTo + 97));
        }

        return answer.ToString();
    }
}

public class ShiftingLettersTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "abc",
                    new[] {new[] {0, 1, 0}, new[] {1, 2, 1}, new[] {0, 2, 1}},
                    "ace"
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Shifting_letters_tests(string s, int[][] data, string expected)
    {
        var result = new ShiftingLetters().Shift(s, data);
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Shifting_letters_Opt_tests(string s, int[][] data, string expected)
    {
        var result = new ShiftingLetters().ShiftOptimal(s, data);
        result.Should().Be(expected);
    }
}