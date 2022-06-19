using System.Text;

namespace Problems.Google;

public static class LicenseKeyFormatting
{
    public static string Execute(string s, int k)
    {
        var sb = new StringBuilder();
        var n = s.Length;
        var count = 0;
        var i = n - 1;
        while (i >= 0)
        {
            var current = char.ToUpper(s[i]);
            var checkModulo = count % k;
            if (current == '-')
            {
                i--;
            }
            else if (count == k)
            {
                sb.Insert(0, '-');
                count = 0;
            }
            else
            {
                sb.Insert(0, current);
                count++;
                i--;
            }
        }

        return sb.ToString();
    }
}