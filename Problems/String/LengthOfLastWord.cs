namespace Problems.String;

public static class LengthOfLastWord
{
    public static int Execute(string sentence)
    {
        var trimmed = sentence.TrimEnd();

        var split = trimmed.Split(" ");
        
        return split.Last().Length;
    }
}