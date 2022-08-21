using System.Text;

namespace Problems.DP;

public class InterleavingString
{
    private readonly Dictionary<(int left, int right), bool> _cache = new();

    public bool IsInterleave(string s1, string s2, string s3)
    {
        if (s3.Length > s1.Length + s2.Length)
            return false;

        if (string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2) && string.IsNullOrEmpty(s3))
            return true;

        return Dfs(0, 0, s1, s2, s3, new StringBuilder());
    }

    private bool Dfs(int left, int right, string s1, string s2, string s3, StringBuilder path)
    {
        if (left + right > s3.Length)
            return false;
        var current = path.ToString();
        if (path.Length > 0 && !s3.StartsWith(current))
            return false;

        if (_cache.ContainsKey((left, right)))
            return _cache[(left, right)];

        if (current == s3)
            return true;

        bool resultOne = false, resultTwo = false;

        if (left < s1.Length)
        {
            var fromOne = s1[left];
            resultOne = Dfs(left + 1, right, s1, s2, s3, path.Append(fromOne));
            path.Remove(path.Length - 1, 1); // Removes last
        }

        if (right < s2.Length)
        {
            var fromTwo = s2[right];
            resultTwo = Dfs(left, right + 1, s1, s2, s3, path.Append(fromTwo));
            path.Remove(path.Length - 1, 1); // Removes last
        }

        return _cache[(left, right)] = resultOne || resultTwo;
    }

    public bool IsInterleaveBottomUp(string s1, string s2, string s3)
    {
        if (s3.Length != s1.Length + s2.Length)
            return false;

        if (string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2) && string.IsNullOrEmpty(s3))
            return true;

        var dp = new bool[s1.Length + 1][];
        for (var i = 0; i <= s1.Length; i++)
            dp[i] = new bool[s2.Length + 1];

        dp[s1.Length][s2.Length] = true;

        for (var i = s1.Length; i >= 0; i--)
        for (var j = s2.Length; j >= 0; j--)
        {
            if (i < s1.Length && s1[i] == s3[i + j] && dp[i + 1][j])
                dp[i][j] = true;
            if (j < s2.Length && s2[j] == s3[i + j] && dp[i][j + 1])
                dp[i][j] = true;
        }

        return dp[0][0];
    }
}