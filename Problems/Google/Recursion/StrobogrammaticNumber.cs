namespace Problems.Google.Recursion;

public class StrobogrammaticNumber
{
    private readonly IReadOnlyDictionary<char, char> _rotates = new Dictionary<char, char>
    {
        {'0', '0'},
        {'1', '1'},
        {'8', '8'},
        {'6', '9'},
        {'9', '6'}
    };

    public bool IsStrobogrammatic(string num)
    {
        var n = num.Length;

        for (var i = 0; i < n; i++)
        {
            var current = num[i];
            var last = num[n - 1 - i];
            if (!_rotates.ContainsKey(current) || !_rotates.ContainsKey(last))
                return false;

            if (current != _rotates[last])
                return false;
        }

        return true;
    }

    /// <summary>
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public IList<string> SlowFindStrobogrammatic(int n)
    {
        if (n > 14)
            throw new InvalidOperationException("n cannot be more than 14");

        var power = (long) Math.Pow(10, n - 1);

        if (power % 2 == 1)
            power--;

        var limit = (long) Math.Pow(10, n);
        var result = new List<string>();

        for (var i = power; i < limit; i++)
        {
            var current = i.ToString();

            if (IsStrobogrammatic(current))
                result.Add(i.ToString());
        }

        return result;
    }

    private List<string> GenerateStroboNumbers(int n, int finalLength)
    {
        if (n == 0)
            return new List<string> {""};

        if (n == 1)
            return new List<string> {"0", "1", "8"};

        var previousStroboNums = GenerateStroboNumbers(n - 2, finalLength);
        var current = new List<string>();

        foreach (var prev in previousStroboNums)
        foreach (var rotate in _rotates)
            if (rotate.Key != '0' || n != finalLength)
                current.Add(rotate.Key + prev + rotate.Value);

        return current;
    }

    public List<string> FindStrobogrammatic(int n)
    {
        return GenerateStroboNumbers(n, n);
    }
}