namespace Problems.Google.Arrays;

public static class LongestSubstring
{
    #region Bruteforce

    public static int LengthOfLongestSubstringBruteForce(string s)
    {
        int n = s.Length;
        int result = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                if (Check(s, i, j))
                {
                    result = Math.Max(result, j - i + 1);
                }
            }
        }

        return result;

    }

    #endregion
    
    #region optimal

    public static int LengthOfLongestSubstring(string s)
    {
        Span<int?> chars = stackalloc int?[128];
        int left = 0;
        int right = 0;
        
        int result = 0;

        while (right < s.Length)
        {
            char r = s[right];
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
        for (int i = start; i <= end; i++)
        {
            char current = s[i];
            if (check[current])
            {
                return false;
            }

            check[current] = true;
        }
        return true;
    }
}