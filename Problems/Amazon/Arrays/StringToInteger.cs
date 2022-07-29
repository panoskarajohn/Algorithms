namespace Problems.Amazon.Arrays;

public class StringToInteger
{
    public int MyAtoi(string s)
    {
        var sign = 1;
        var result = 0;
        var index = 0;
        var n = s.Length;

        while (index < n && s[index] == ' ')
            index++;

        if (index < n && s[index] == '+')
        {
            index++;
        }
        else if (index < n && s[index] == '-')
        {
            index++;
            sign = -1;
        }

        while (index < n && char.IsDigit(s[index]))
        {
            var digit = s[index] - '0';
            // check overflow
            if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && digit > int.MaxValue % 10))
                return sign == 1 ? int.MaxValue : int.MinValue;
            result = 10 * result + digit;
            index++;
        }

        return result * sign;
    }
}