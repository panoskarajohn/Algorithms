namespace Problems.Google.Arrays;

public static class ExpressiveWords
{
    public static int Get(string s, string[] words)
    {
        var counter = 0;
        foreach (var word in words)
            if (Expressive(s, word, 0, 0))
                counter++;

        return counter;
    }

    private static bool Expressive(string s, string t, int si, int ti)
    {
        if (si == s.Length && ti == t.Length) return true;

        if (si == s.Length || ti == t.Length || s[si] != t[ti]) return false;

        var cur = s[si];

        int scount = 0, tcount = 0;

        while (si < s.Length && s[si] == cur)
        {
            scount++;
            si++;
        }

        while (ti < t.Length && t[ti] == cur)
        {
            tcount++;
            ti++;
        }

        return (scount == tcount || (scount >= 3 && scount > tcount)) && Expressive(s, t, si, ti);
    }
}