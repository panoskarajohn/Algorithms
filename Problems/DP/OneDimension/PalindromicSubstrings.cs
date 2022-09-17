namespace Problems.DP.OneDimension;

public class PalindromicSubstrings
{
    /// <summary>
    ///     Similar problem to the <see cref="LongestPalindromicSubstring" />
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int CountSubstrings(string s)
    {
        var result = 0;

        for (var i = 0; i < s.Length; i++)
        {
            result += Expand(s, i, i);
            result += Expand(s, i, i + 1);
        }

        return result;
    }

    private int Expand(string s, int left, int right)
    {
        var result = 0;
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
            result++;
        }

        return result;
    }
}