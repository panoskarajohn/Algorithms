namespace Problems.Google.Arrays;

public class BackspaceStringCompare
{
    /// <summary>
    /// Brute force solution O(n) but space O(n)
    /// Question specifically asks for space O(1)
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static bool Compare(string s, string t)
    {
        var stackS = new Stack<char>();
        var stackT = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '#' && stackS.Count > 0)
                stackS.Pop();
            else
            {
                if (s[i] != '#')
                    stackS.Push(s[i]);
            }
        }
        
        for (int i = 0; i < t.Length; i++)
        {
            if (t[i] == '#' && stackT.Count > 0)
                stackT.Pop();
            else
            {
                if (t[i] != '#')
                    stackT.Push(t[i]);
            }
        }

        if (stackS.Count != stackT.Count)
            return false;

        return stackS.SequenceEqual(stackT);
    }

    public static bool CompareOptimal(string s, string t)
    {
        int sPointer = s.Length - 1;
        int tPointer = t.Length - 1;
        int skipS = 0;
        int skipT = 0;

        while (tPointer >= 0 || sPointer >= 0)
        {
            while (sPointer >= 0)
            {
                if (s[sPointer] == '#')
                {
                    skipS++;
                    sPointer--;
                }
                else if (skipS > 0)
                {
                    skipS--;
                    sPointer--;
                }
                else
                {
                    break;
                }
            }
            
            while (tPointer >= 0)
            {
                if (t[tPointer] == '#')
                {
                    skipT++;
                    tPointer--;
                }
                else if (skipT > 0)
                {
                    skipT--;
                    tPointer--;
                }
                else
                {
                    break;
                }
            }

            if (sPointer >= 0 && tPointer >= 0 && s[sPointer] != t[tPointer])
                return false;
            
            if (sPointer >= 0 != tPointer >= 0)
                return false;

            sPointer--;
            tPointer--;
        }

        return true;
    }
}