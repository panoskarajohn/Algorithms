using System.Collections;
using System.Collections.ObjectModel;
using System.Text;

namespace Problems.Google.Recursion;

public class GenerateParentheses
{
    private IReadOnlyDictionary<char, char> _reverse = new Dictionary<char, char>()
    {
        {'(', ')'}
    };

    private int _size = 0;
    private List<string> _combinations = new();
    
    public IList<string> Get(int n)
    {
        _size = n * 2;
        Backtrack(0, new StringBuilder().Append('('));
        return _combinations;
    }

    private void Backtrack(int step, StringBuilder path)
    {
        if (path.Length == _size)
        {
            if (IsValidParentheses(path.ToString()))
            {
                _combinations.Add(path.ToString());
            }
            return;
        }

        var combinations = new char[] {'(', ')'};
        foreach (var combination in combinations)
        {
            path.Append(combination);
            Backtrack(step + 1, path);
            path.Remove(path.Length - 1, 1);
        }
    }
    private bool IsValidParentheses(string parentheses)
    {
        var stack = new Stack<char>();
        for (int i = 0; i < parentheses.Length; i++)
        {
            var current = parentheses[i];
            if (!stack.Any())
            {
                if (!_reverse.ContainsKey(current))
                    return false;
                
                stack.Push(current);
                continue;
            }

            var peek = stack.Peek();
            if (_reverse.ContainsKey(peek) && _reverse[peek] == current)
            {
                stack.Pop();
            }
            else
            {
                if (!_reverse.ContainsKey(current))
                    return false;
                stack.Push(current);
            }
        }

        return !stack.Any(); //stack should be empty
    }
}