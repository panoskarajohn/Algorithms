namespace Problems.Array;

public class StrStr
{
    public static int Execute(string haystack, string needle)
    {
        if (string.IsNullOrWhiteSpace(needle))
            return 0;

        if (haystack.Length == 1)
            return 0;

        var needleIndex = 0;
        var firstIndex = -1;

        for (var i = 0; i < haystack.Length; i++)
        {
            var curHaystack = haystack[i];
            var curNeedle = needle[needleIndex];

            var isMatch = curHaystack == curNeedle;

            if (isMatch)
            {
                if (firstIndex == -1)
                    firstIndex = i;
                needleIndex++; // a
            }

            if (!isMatch && firstIndex != -1) // Reset values
            {
                needleIndex = 0;
                i = firstIndex;
                firstIndex = -1;
            }

            if (needleIndex == needle.Length)
                return firstIndex;
        }

        return -1;
    }
}