namespace Problems.Google.String;

public class ValidParentheses
{
    private readonly Dictionary<char, char> reverse = new()
    {
        {'(', ')'},
        {'[', ']'},
        {'{', '}'}
    };

    public bool IsValid(string s)
    {
        var stack = new Stack<char>();

        for (var i = 0; i < s.Length; i++)
        {
            var current = s[i];

            if (!stack.Any())
            {
                if (!reverse.ContainsKey(current))
                    return false;

                stack.Push(current);
            }
            else
            {
                var peek = stack.Peek();
                if (reverse.ContainsKey(peek) && reverse[peek] == current)
                {
                    stack.Pop();
                }
                else
                {
                    if (!reverse.ContainsKey(current))
                        return false;
                    stack.Push(current);
                }
            }
        }

        return !stack.Any();
    }
}