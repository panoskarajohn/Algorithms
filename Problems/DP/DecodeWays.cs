namespace Problems.DP;

public class DecodeWays
{
    #region TopDown
    private readonly Dictionary<int, int> _cache = new Dictionary<int, int>();
    public int NumDecodings(string s)
    {
        return Dfs(0,  s);
    }

    int Dfs(int index, string s)
    {
        if (_cache.ContainsKey(index))
            return _cache[index];

        if (index == s.Length)
            return 1;

        if (s[index] == '0')
            return 0;

        if (index == s.Length - 1)
            return 1;

        int one = Dfs(index + 1, s);
        var number = int.Parse(s[index..(index + 2)]);
        if (number <= 26)
        {
            one += Dfs(index + 2, s);
        }

        _cache[index] = one;
        return _cache[index];

    }
    
    #endregion

    public int NumWaysDecodingBottomUp(string s)
    {
        if (s.StartsWith('0'))
            return 0;
        int n = s.Length;
        
        var dp = new int[n];
        dp[n - 1] = s[n - 1] == '0' ? 0 : 1;

        for (int i = n - 2; i >= 0; i--)
        {
            var answer = dp[i + 1];
            if (s[i] == '0')
            {
                dp[i] = 0;
                continue;
            }
            int number = int.Parse(s[i..(i + 2)]);
            if (number > 26)
            {
                dp[i] = answer;
                continue;
            }

            if (i + 2 < n)
            {
                answer += dp[i + 2];
            }
            else
            {
                answer++;
            }

            dp[i] = answer;
        }

        return dp[0];
    }
}