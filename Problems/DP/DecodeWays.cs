namespace Problems.DP;

public class DecodeWays
{
    public int NumWaysDecodingBottomUp(string s)
    {
        if (s.StartsWith('0'))
            return 0;
        var n = s.Length;

        var dp = new int[n];
        dp[n - 1] = s[n - 1] == '0' ? 0 : 1;

        for (var i = n - 2; i >= 0; i--)
        {
            var answer = dp[i + 1];
            if (s[i] == '0')
            {
                dp[i] = 0;
                continue;
            }

            var number = int.Parse(s[i..(i + 2)]);
            if (number > 26)
            {
                dp[i] = answer;
                continue;
            }

            if (i + 2 < n)
                answer += dp[i + 2];
            else
                answer++;

            dp[i] = answer;
        }

        return dp[0];
    }

    #region LeetCode Solution

    public int NumWaysDecodingBottomUpClean(string s)
    {
        if (s[0] == '0') return 0;
        int n = s.Length;


        int oneBack = 1;
        int twoBack = 1;

        for (var i = 1; i < n; i++)
        {
            int current = 0;
            if (s[i] != '0') current = oneBack;

            int twoDigit = (s[i - 1] - '0') * 10 
                + s[i] - '0';
            
            if (twoDigit >= 10 && twoDigit <= 26) 
                current += twoBack;

            twoBack = oneBack;
            oneBack = current;
        }

        return oneBack;
    }

    #endregion

    #region TopDown

    private readonly Dictionary<int, int> _cache = new();

    public int NumDecodings(string s)
    {
        return Dfs(0, s);
    }

    private int Dfs(int index, string s)
    {
        if (_cache.ContainsKey(index))
            return _cache[index];

        if (index == s.Length)
            return 1;

        if (s[index] == '0')
            return 0;

        if (index == s.Length - 1)
            return 1;

        var one = Dfs(index + 1, s);
        var number = int.Parse(s[index..(index + 2)]);
        if (number <= 26) one += Dfs(index + 2, s);

        _cache[index] = one;
        return _cache[index];
    }

    #endregion
}