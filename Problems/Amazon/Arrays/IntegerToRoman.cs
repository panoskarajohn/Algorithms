using System.Collections.ObjectModel;
using System.Text;
using Problems.Google.GraphsTrees;

namespace Problems.Amazon.Arrays;

public class IntegerToRoman
{
    private readonly IReadOnlyDictionary<int, string> _intRomanMap = new Dictionary<int, string>
    {
        {1, "I"},
        {4, "IV"},
        {5, "V"},
        {9, "IX"},
        {10, "X"},
        {40, "XL"},
        {50, "L"},
        {90, "XC"},
        {100, "C"},
        {400, "CD"},
        {500, "D"},
        {900, "CM"},
        {1000, "M"}
    };

    private readonly HashSet<char> _combo = new()
    {
        'I', 'X', 'C'
    };

    public string ConvertFromInteger(int number)
    {
        var sb = new StringBuilder();
        var keys = _intRomanMap.Keys.Reverse();

        while (number != 0)
            foreach (var key in keys)
            {
                var time = number / key;
                for (var i = 0; i < time; i++)
                    sb.Append(_intRomanMap[key]);
                number -= time * key;

                if (number == 0) break;
            }

        return sb.ToString();
    }
    
}