namespace Problems.Google.Arrays;

public static class LongestSubstring
{
    #region Bruteforce

    public static int LengthOfLongestSubstringBruteForce(string s)
    {
        var n = s.Length;
        var result = 0;

        for (var i = 0; i < n; i++)
        for (var j = i; j < n; j++)
            if (Check(s, i, j))
                result = Math.Max(result, j - i + 1);

        return result;
    }

    #endregion

    #region optimal

    public static int LengthOfLongestSubstring(string s)
    {
        Span<int?> chars = stackalloc int?[128];
        var left = 0;
        var right = 0;

        var result = 0;

        while (right < s.Length)
        {
            var r = s[right];
            var index = chars[r];

            if (index is not null && index >= left && index < right)
                left = index.Value + 1;

            result = Math.Max(result, right - left + 1);
            chars[r] = right;
            right++;
        }

        return result;
    }

    #endregion

    public static bool Check(string s, int start, int end)
    {
        Span<bool> check = stackalloc bool[128];
        for (var i = start; i <= end; i++)
        {
            var current = s[i];
            if (check[current]) return false;

            check[current] = true;
        }

        return true;
    }
}