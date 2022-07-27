namespace Problems.Google.DP;

public class LongestPalindromicSubstring
{
    public string Get(string s)
    {
        if (string.IsNullOrEmpty(s))
            return string.Empty;

        int start = 0;
        int end = 0;

        for (int i = 0; i < s.Length; i++)
        {
            int lengthOne = Expand(s, i, i);
            int lengthTwo = Expand(s, i, i + 1);
            int maxLength = Math.Max(lengthOne, lengthTwo);

            if (maxLength > end - start)
            {
                start = i - (maxLength - 1) / 2;
                end = i + maxLength / 2;
            }
        }

        return s[start..(end+1)];
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