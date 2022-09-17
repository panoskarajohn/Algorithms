namespace Problems.Google.DP;

public class LongestPalindromicSubstring
{
    public string Get(string s)
    {
        if (string.IsNullOrEmpty(s))
            return string.Empty;

        var start = 0;
        var end = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var lengthOne = Expand(s, i, i); // odd palindromes
            var lengthTwo = Expand(s, i, i + 1); // edge case for even palindromes
            var maxLength = Math.Max(lengthOne, lengthTwo);

            if (maxLength > end - start)
            {
                start = i - (maxLength - 1) / 2;
                end = i + maxLength / 2;
            }
        }

        return s[start..(end + 1)];
    }

    private int Expand(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
        }

        return right - left - 1;
    }
}