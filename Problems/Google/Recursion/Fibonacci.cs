namespace Problems.Google.Recursion;

public class Fibonacci
{
    private Dictionary<int, int> _cache = new ();
    public int Fib(int n)
    {
        if (_cache.ContainsKey(n))
            return _cache[n];
        
        if (n < 2) return n;
        
        var result = Fib(n - 1) + Fib(n - 2);
        _cache.Add(n, result);
        return result;
    }
}