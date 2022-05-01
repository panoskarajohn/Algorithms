using System.Text;
using Microsoft.CSharp.RuntimeBinder;

namespace Problems.Google.Arrays;

public class FindAndReplace
{
    public static string FindReplaceString(string s, int[] indices, string[] sources, string[] targets)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            var index = System.Array.IndexOf(indices, i);
            
            if (index != -1)
            {
                var sourceAtIndex = sources[index];
                bool sourceFound = true;
                for (int j = 0; j < sourceAtIndex.Length; j++)
                {
                    if (i + j >= s.Length && j < sourceAtIndex.Length)
                    {
                        sourceFound = false;
                        break;
                    }

                    if (i + j >= s.Length)
                        break;

                    if (s[i + j] != sourceAtIndex[j])
                    {
                        sourceFound = false;
                        break;
                    }
                }

                if (sourceFound && index < targets.Length)
                {
                    sb.Append(targets[index]);
                    i += sourceAtIndex.Length - 1;
                }
                
                else
                {
                    sb.Append(s[i]);
                }
            }
            else
            {
                sb.Append(s[i]);
            }
        }
        return sb.ToString();
    }
}