using System.Collections;
using System.Text;

namespace Problems.Google.GraphsTrees;

public class DecodeString
{
    public string Decode(string s)
    {
        int n = s.Length;
        var stack = new Stack<char>();

        for (int i = 0; i < n; i++)
        {
            if (s[i] == ']')
            {
                var decodedString = new List<char>();
                
                //get the encoding string
                while (stack.Peek() != '[')
                {
                    decodedString.Add(stack.Pop());
                }
                
                //pop the [
                stack.Pop();
                int baseOfTen = 1;
                int multiplier = 0;

                while (stack.Any() && char.IsDigit(stack.Peek()))
                {
                    multiplier += (stack.Pop() - '0') * baseOfTen;
                    baseOfTen *= 10;
                }

                while (multiplier != 0)
                {
                    // append the decoded string to the stack
                    for (int j = decodedString.Count - 1; j >= 0; j--)
                    {
                        stack.Push(decodedString[j]);
                    }

                    multiplier--;
                }
            }
            else
            {
                stack.Push(s[i]);
            }
        }
        
        char[] result = new char[stack.Count];
        for (int i = result.Length - 1; i >= 0; i--)
        {
            result[i] = stack.Pop();
        }

        return new string(result);
    }
}