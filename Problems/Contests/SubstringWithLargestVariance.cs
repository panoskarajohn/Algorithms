using Problems.PrefixSum;

namespace Problems.Contests;

public class SubstringWithLargestVariance
{
    public int LargestVariance(string s)
    {
        var n = s.Length;
        var seen = new HashSet<int>();
        var s2 = new int[n];
        for (var i = 0; i < n; i++)
        {
            var current = s[i] - 'a';
            seen.Add(current);
            s2[i] = current;
        }

        var max = 0;

        for (var i = 0; i < 26; i++)
            if (seen.Contains(i))
                for (var j = 0; j < 26; j++)
                    if (seen.Contains(j) && i != j)
                    {
                        var left = 0;
                        var lastT = -1;
                        var count = 0;
                        var prefix = 0;
                        var minx = 0;

                        for (var t = 0; t < n; t++)
                        {
                            if (s2[t] == i)
                            {
                                count++;
                            }
                            else if (s2[t] == j)
                            {
                                count--;
                                lastT = t;
                            }

                            while (left < lastT)
                            {
                                if (s2[left] == i)
                                    prefix++;
                                else if (s2[left] == j) prefix--;

                                if (minx > prefix)
                                {
                                    minx = prefix;
                                }

                                left++;
                            }

                            if (lastT != -1 && count - minx > max)
                            {
                                max = count - minx;
                            }

                        }
                    }

        return max;
    }
}