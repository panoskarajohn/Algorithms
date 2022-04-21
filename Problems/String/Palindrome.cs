using System.Text.RegularExpressions;

namespace Problems.String;

public static class Palindrome
{
    /// <summary>
    /// Checks whether a word is a Palindrome
    /// </summary>
    /// <remarks>Will remove whitespace and convert to lowercase</remarks>
    /// <param name="word"></param>
    /// <returns></returns>
    public static bool IsPalindrome(string word)
    {
        var wordTypified = TypifyString(word);
        var reversed = ReverseString(wordTypified);
        return wordTypified.Equals(reversed);
    }

    /// <summary>
    /// Remove whitespace and convert to lower invariant
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>
    private static string TypifyString(string word) 
        => Regex.Replace(word.ToLowerInvariant(), @"\s+", "");

    /// <summary>
    /// Reverses a given string
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>
    private static string ReverseString(string word)
    {
        var wordArray = word.ToCharArray();
        System.Array.Reverse(wordArray);
        return new(wordArray);
    }

}