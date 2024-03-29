﻿namespace Problems.Google.Arrays;

public class LongestSubstringWithAtMostTwoCharsDistinct
{
    private char[] ara = new char[4];

    public static int Get(string s)
    {
        var dictionary = new Dictionary<char, int>();
        var right = 0;
        var left = 0;

        var result = 1;

        while (right < s.Length)
        {
            var current = s[right];
            if (dictionary.Count <= 2)
            {
                if (dictionary.ContainsKey(current))
                    dictionary[current] = right++;
                else
                    dictionary.Add(current, right++);
            }

            if (dictionary.Count > 2)
            {
                var min = s.Length - 1;
                foreach (var kv in dictionary)
                    if (kv.Value < min)
                        min = kv.Value;

                left = min + 1;
                dictionary.Remove(s[min]);
            }

            result = Math.Max(result, right - left);
        }

        return result;
    }
}