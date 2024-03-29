﻿namespace Problems.Amazon.Arrays;

public class LengthOfLongestSubstring
{
    public int Get(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        var visited = new bool[128];
        var left = 0;
        var right = 0;
        var max = int.MinValue;
        while (right < s.Length && left < s.Length)
            if (!visited[s[right]])
            {
                visited[s[right]] = true;
                max = Math.Max(max, right - left + 1);
                right++;
            }
            else
            {
                visited[s[left]] = false;
                left++;
            }

        return max;
    }
}