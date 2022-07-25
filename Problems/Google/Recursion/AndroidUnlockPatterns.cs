using System.Net;

namespace Problems.Google.Recursion;

public class AndroidUnlockPatterns
{
    private readonly IDictionary<(int min, int max), int> _checkTransitions = new Dictionary<(int min, int max), int>()
    {
        {(1,3), 2},
        {(1,7), 4},
        {(1,9), 5},
        {(2,8), 5},
        {(3,9), 6},
        {(3,7), 5},
        {(4,6), 5},
        {(7,9), 8}
    };

    private void Helper(ref int res, int m, int n, int currentLength, int from, int pattern)
    {
        if (currentLength >= m)
        {
            res++;
        }

        if (currentLength == n)
        {
            return;
        }

        for (int i = 0; i < 9; i++)
        {
            if ((pattern & (1 << i)) == 0)
            {
                (int min, int max) key = (Math.Min(from, i) + 1, Math.Max(from, i) + 1);
                    
                if (!_checkTransitions.ContainsKey(key) || (pattern & (1 << (_checkTransitions[key] - 1))) != 0)
                {
                    pattern = pattern ^ (1 << i);
                    Helper(ref res, m, n, currentLength + 1, i, pattern);
                    pattern = pattern ^ (1 << i);
                }
            }
        }
    }

    /// <summary>
    ///     Wtf problem, also not clear description!!!
    ///     It has a knight move!
    ///     https://leetcode.com/problems/android-unlock-patterns/
    /// </summary>
    /// <param name="m"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int NumberOfPatterns(int m, int n)
    {
        int res = 0;
        Helper(ref res,m,n,0, -1, 0);
        return res;
    }
}