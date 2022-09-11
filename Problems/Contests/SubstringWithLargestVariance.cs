using System.Text;
using Problems.PrefixSum;

namespace Problems.Contests;

public class SubstringWithLargestVariance
{
    public int LargestVariance(string s)
    {
        int answer = 0;
        char a = 'a';
        for (int i = 0; i < 26; i++)
        {
            for (int j = 0; j < 26; j++)
            {
                if (a + i != a + j)
                {
                    int subAnswer = Kadane((char)(a + i), (char)(a + j), s);
                    answer = Math.Max(answer, subAnswer);
                }
            }
        }

        return answer;
    }

    /// <summary>
    /// 1. kadane(a,b) is not symmetric, kadane(a,b) != kadane(b,a)
    /// 2. finer details
    ///  -> Iterate over the pairs
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    int Kadane(char a, char b, string s)
    {
        int answer = 0;

        int countA = 0, countB = 0;
        bool canExtendPreviousB = false;

        for (int i = 0; i < s.Length; i++)
        {
            var current = s[i];
            if (current != a && current != b)
            {
                continue;
            }

            if (current == a)
                countA++;
            else
            {
                countB++;
            }

            if (countB > 0) // we need at least one b
                answer = Math.Max(answer, countA - countB);
            else if (countB == 0 && canExtendPreviousB)
            {
                // consider/imagine a prefix
                answer = Math.Max(answer, countA - 1);
            }

            if (countB > countA)
            {
                countA = 0;
                countB = 0;
                canExtendPreviousB = true;
            }
        }
        
        return answer;
    }
}