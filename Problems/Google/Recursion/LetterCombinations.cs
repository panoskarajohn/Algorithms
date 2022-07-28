using System.Text;

namespace Problems.Google.Recursion;

public class LetterCombinations
{
    private readonly List<string> _combinations = new();

    private readonly IReadOnlyDictionary<char, char[]> _phoneKeys = new Dictionary<char, char[]>
    {
        {'2', new[] {'a', 'b', 'c'}},
        {'3', new[] {'d', 'e', 'f'}},
        {'4', new[] {'g', 'h', 'i'}},
        {'5', new[] {'j', 'k', 'l'}},
        {'6', new[] {'m', 'n', 'o'}},
        {'7', new[] {'p', 'q', 'r', 's'}},
        {'8', new[] {'t', 'u', 'v'}},
        {'9', new[] {'w', 'x', 'y', 'z'}}
    };

    private string _digits;

    public IList<string> Get(string digits)
    {
        if (string.IsNullOrEmpty(digits))
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