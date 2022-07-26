using System.Text;

namespace Problems.Google.Recursion;

public class LetterCombinations
{
    private readonly IReadOnlyDictionary<char, char[]> _phoneKeys = new Dictionary<char, char[]>()
    {
        {'2', new char[]{ 'a', 'b', 'c' }},
        {'3', new char[]{ 'd', 'e', 'f' }},
        {'4', new char[]{ 'g', 'h', 'i' }},
        {'5', new char[]{ 'j', 'k', 'l' }},
        {'6', new char[]{ 'm', 'n', 'o' }},
        {'7', new char[]{ 'p', 'q', 'r', 's' }},
        {'8', new char[]{ 't', 'u', 'v' }},
        {'9', new char[]{ 'w', 'x', 'y', 'z' }}
    };

    private string _digits;
    private readonly List<string> _combinations = new List<string>();

    public IList<string> Get(string digits)
    {
        if(string.IsNullOrEmpty(digits))
            return _combinations;
        _digits = digits;
        
        Backtrack(0, new StringBuilder());
    
        return _combinations;
    }

    private void Backtrack(int index, StringBuilder sb)
    {
        if (sb.Length == _digits.Length)
        {
            _combinations.Add(sb.ToString());
            return;
        }

        var possibleLetters = _phoneKeys[_digits[index]];
        foreach (var letter in possibleLetters)
        {
            sb.Append(letter);
            Backtrack(index + 1, sb);
            sb.Remove(sb.Length - 1, 1);
        }
    }
}