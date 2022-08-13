using FluentAssertions;

namespace Problem.Tests.Amazon.Arrays;

public class ReorderLogFilesTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {"dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero"},
                    new[] {"let1 art can", "let3 art zero", "let2 own kit dig", "dig1 8 1 5 1", "dig2 3 6"}
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Reorder_log_files(string[] input, string[] expected)
    {
        var result = new ReorderLogFiles().Reorder(input);
        result.Should().BeEquivalentTo(expected);
    }
}

public class ReorderLogFiles
{
    public string[] Reorder(string[] logs)
    {
        var letterLogs = new List<string>();
        var digiLogs = new List<string>();

        for (var i = 0; i < logs.Length; i++)
        {
            var parts = logs[i].Split(' ');
            if (char.IsDigit(parts[1][0]))
                digiLogs.Add(logs[i]);
            else
                letterLogs.Add(logs[i]);
        }

        letterLogs.Sort(Compare);
        letterLogs.AddRange(digiLogs);

        return letterLogs.ToArray();
    }

    public static int Compare(string log1, string log2)
    {
        var split1 = log1.Split(" ", 2);
        var split2 = log2.Split(" ", 2);

        var isDigit1 = char.IsDigit(split1[1][0]);
        var isDigit2 = char.IsDigit(split2[1][0]);

        // case 1). both logs are letter-logs
        if (!isDigit1 && !isDigit2)
        {
            // first compare the content
            var cmp = split1[1].CompareTo(split2[1]);
            if (cmp != 0)
                return cmp;
            // logs of same content, compare the identifiers
            return split1[0].CompareTo(split2[0]);
        }

        // case 2). one of logs is digit-log
        if (!isDigit1 && isDigit2)
            // the letter-log comes before digit-logs
            return -1;
        if (isDigit1 && !isDigit2)
            return 1;
        return 0;
    }
}