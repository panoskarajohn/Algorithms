namespace Problems.Google.Arrays;

public static class MinimumWindowSubstring
{
    public static string Get(string s, string t)
    {
        if (s.Length == 0 || t.Length == 0)
            return string.Empty;

        var dictionaryT = new Dictionary<char, int>();
        for (var i = 0; i < t.Length; i++)
            if (dictionaryT.ContainsKey(t[i]))
                dictionaryT[t[i]]++;
            else
                dictionaryT.Add(t[i], 1);

        var requiredCharacters = dictionaryT.Count;
        var formed = 0;

        var right = 0;
        var left = 0;

        int[] answers = {-1, 0, 0};

        var dictionaryWindow = new Dictionary<char, int>();

        while (right < s.Length)
        {
            var current = s[right];
            if (dictionaryWindow.ContainsKey(current))
                dictionaryWindow[current]++;
            else
                dictionaryWindow.Add(current, 1);

            if (dictionaryT.ContainsKey(current) && dictionaryT[current] == dictionaryWindow[current]) formed++;

            while (left <= right && formed == requiredCharacters)
            {
                var leftChar = s[left];
                if (answers[0] == -1 || right - left + 1 < answers[0])
                {
                    answers[0] = right - left + 1;
                    answers[1] = left;
                    answers[2] = right;
                }

                // the left part of the window is no longer part of the window
                if (dictionaryWindow.ContainsKey(leftChar)) dictionaryWindow[leftChar]--;

                if (dictionaryT.ContainsKey(leftChar) && dictionaryWindow[leftChar] < dictionaryT[leftChar]) formed--;

                left++;
            }

            right++;
        }

        return answers[0] == -1 ? string.Empty : s[answers[1]..(answers[2] + 1)];
    }
}