namespace Problems.Google.Sorting;

public class ValidAnagram
{
    public bool IsAnagram(string s, string t)
    {
        var sChar = s.ToCharArray();
        var tChar = t.ToCharArray();
        System.Array.Sort(sChar);
        System.Array.Sort(tChar);
        return sChar.SequenceEqual(tChar);
    }
}