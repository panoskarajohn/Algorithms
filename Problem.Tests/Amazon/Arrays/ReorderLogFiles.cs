using FluentAssertions;

namespace Problem.Tests.Amazon.Arrays;

public class ReorderLogFilesTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Reorder_log_files(string[] input, string[] expected)
    {
        var result = new ReorderLogFiles().Reorder(input);
        result.Should().BeEquivalentTo(expected);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new string[] { "dig1 8 1 5 1","let1 art can","dig2 3 6","let2 own kit dig","let3 art zero" },
                    new string[] { "let1 art can","let3 art zero","let2 own kit dig","dig1 8 1 5 1","dig2 3 6" },
                }
            };
        }
    }
}

public class ReorderLogFiles
{
    
    public string[] Reorder(string[] logs)
    {
        List<string> letterLogs = new List<string>();
        List<string> digiLogs = new List<string>();
        
        for (int i = 0; i < logs.Length; i++)
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
        string[] split1 = log1.Split(" ", 2);
        string[] split2 = log2.Split(" ", 2);

        bool isDigit1 = char.IsDigit(split1[1][0]);
        bool isDigit2 = char.IsDigit(split2[1][0]);

        // case 1). both logs are letter-logs
        if (!isDigit1 && !isDigit2) {
            // first compare the content
            int cmp = split1[1].CompareTo(split2[1]);
            if (cmp != 0)
                return cmp;
            // logs of same content, compare the identifiers
            return split1[0].CompareTo(split2[0]);
        }

        // case 2). one of logs is digit-log
        if (!isDigit1 && isDigit2)
            // the letter-log comes before digit-logs
            return -1;
        else if (isDigit1 && !isDigit2)
            return 1;
        else
            // case 3). both logs are digit-log
            return 0;
    }
}