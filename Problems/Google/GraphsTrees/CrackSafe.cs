using System.Text;

namespace Problems.Google.GraphsTrees;

public class CrackSafe
{
    private StringBuilder _answer;

    /*
     * The solution that was showcased was with Euler's path
     * This problem needs to be revisited
     * Hard problem
     * Hint:
     * We can think of this problem as the problem of finding an Euler path (a path visiting every edge exactly once)
     * on the following graph: there are $$k^{n-1}$$ nodes with each node having $$k$$ edges.
     * It turns out this graph always has an Eulerian circuit
     * (path starting where it ends.) We should visit each node in "post-order" so as to not get stuck in the graph prematurely.
     */
    private HashSet<string> _seen;

    /// <summary>
    ///     There is a safe protected by a password.
    ///     The password is a sequence of n digits where each digit can be in the range [0, k - 1].
    /// </summary>
    /// <param name="n"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public string Crack(int n, int k)
    {
        if (n == 0 && k == 0)
            return "0";

        _seen = new HashSet<string>();
        _answer = new StringBuilder();

        var sb = new StringBuilder();

        for (var i = 0; i < n - 1; i++)
            sb.Append("0");

        var start = sb.ToString();

        Dfs(start, k);

        _answer.Append(start);

        return _answer.ToString();
    }

    private void Dfs(string node, int k)
    {
        for (var i = 0; i < k; i++)
        {
            var current = node + i;
            if (!_seen.Contains(current))
            {
                _seen.Add(current);
                Dfs(current.Substring(1), k);

                _answer.Append(i);
            }
        }
    }
}