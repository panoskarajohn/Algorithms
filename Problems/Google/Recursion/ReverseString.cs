namespace Problems.Google.Recursion;

public class ReverseString
{
    public void Reverse(char[] s)
    {
        if (s is null || s.Length == 0)
            return;
        
        Reverse(0, s.Length - 1,s);
    }

    void Reverse(int start, int end, char[] s)
    {
        if (start >= end) return;
        (s[start], s[end]) = (s[end], s[start]);
        Reverse(start + 1, end - 1,s);
    }
}