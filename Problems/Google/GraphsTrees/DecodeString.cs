namespace Problems.Google.GraphsTrees;

public class DecodeString
{
    public string Decode(string s)
    {
        var n = s.Length;
        var stack = new Stack<char>();

        for (var i = 0; i < n; i++)
            if (s[i] == ']')
            {
                var decodedString = new List<char>();

                //get the encoding string
                while (stack.Peek() != '[') decodedString.Add(stack.Pop());

                //pop the [
                stack.Pop();
                var baseOfTen = 1;
                var multiplier = 0;

                while (stack.Any() && char.IsDigit(stack.Peek()))
                {
                    multiplier += (stack.Pop() - '0') * baseOfTen;
                    baseOfTen *= 10;
                }

                while (multiplier != 0)
                {
                    // append the decoded string to the stack
                    for (var j = decodedString.Count - 1; j >= 0; j--) stack.Push(decodedString[j]);

                    multiplier--;
                }
            }
            else
            {
                stack.Push(s[i]);
            }

        var result = new char[stack.Count];
        for (var i = result.Length - 1; i >= 0; i--) result[i] = stack.Pop();

        return new string(result);
    }
}