using System.Text;

namespace Problems.Google;

public static class UniqueEmailAddress
{
    // O(N * M)
    public static int NumUniqueEmails(string[] emails)
    {
        var uniqueEmails = new HashSet<string>();

        foreach (var email in emails)
        {
            var split = email.Split("@");
            var localName = Clean(split[0]);
            var domain = split[1];

            var cleanedEmail = string.Join('@', localName, domain);
            uniqueEmails.Add(cleanedEmail);
        }

        return uniqueEmails.Count;
    }

    private static string Clean(string input)
    {
        var sb = new StringBuilder();

        foreach (var c in input)
        {
            if (c == '.')
                continue;
            if (c == '+')
                break;

            sb.Append(c);
        }


        return sb.ToString();
    }
}