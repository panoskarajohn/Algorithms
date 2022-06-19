using System.Text;

namespace Problems.Array;

public static class LongestCommonPrefix
{
    public static string Execute(string[] strs)
    {
        if (strs.Length == 1)
            return strs[0];

        var prev = string.Empty;

        for (var i = 0; i < strs.Length - 1; i++)
        {
            var commonSubstring = FindCommonSubstring(strs[i], strs[i + 1]);

            if (string.IsNullOrEmpty(commonSubstring))
                return string.Empty;

            if (prev == string.Empty)
            {
                prev = commonSubstring;
            }
            else
            {
                var prevCommon = FindCommonSubstring(commonSubstring, prev);
                if (string.IsNullOrEmpty(prevCommon))
                    return string.Empty;

                prev = prevCommon;
            }
        }

        return prev;
    }

    private static string FindCommonSubstring(string word1, string word2)
    {
        var sb = new StringBuilder();
        var n = word1.Length > word2.Length ? word2.Length : word1.Length; // take the shortest

        for (var i = 0; i < n; i++)
            if (word1[i] == word2[i])
                sb.Append(word1[i]);
            else
                break;

        return sb.ToString();
    }
}