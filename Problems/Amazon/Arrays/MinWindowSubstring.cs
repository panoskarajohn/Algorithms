namespace Problems.Amazon.Arrays;

public class MinWindowSubstring
{
    public string Min(string s, string t)
    {
        if (s.Length == 0 || 
            t.Length == 0 || 
            t.Length > s.Length)
            return string.Empty;

        var dicT = new Dictionary<char, int>();

        for (int i = 0; i < t.Length; i++)
        {
            if (!dicT.ContainsKey(t[i]))
                dicT[t[i]] = 0;
            dicT[t[i]]++;
        }

        int required = dicT.Count;
        int formed = 0;

        int right = 0;
        int left = 0;

        int[] answers = {-1, 0, 0};

        var dictionaryWindow = new Dictionary<char, int>();

        while (right < s.Length)
        {
            var current = s[right];
            
            if (!dictionaryWindow.ContainsKey(current))
                dictionaryWindow[current] = 0;
            dictionaryWindow[current]++;

            if (dicT.ContainsKey(current) && dicT[current] == dictionaryWindow[current])
            {
                formed++;
            }

            while (left <= right && formed == required)
            {
                var leftChar = s[left];
                if (answers[0] == -1 || right - left + 1 < answers[0])
                {
                    answers[0] = right - left + 1;
                    answers[1] = left;
                    answers[2] = right;
                }
                
                //the left part of the window is no longer part of the window
                if (dictionaryWindow.ContainsKey(leftChar))
                {
                    dictionaryWindow[leftChar]--;
                }

                if (dicT.ContainsKey(leftChar) && dictionaryWindow[leftChar] < dicT[leftChar])
                    formed--;

                left++;
            }

            right++;

        }


        return answers[0] == -1 ? string.Empty : s[answers[1]..(answers[2] + 1)];
    }
}