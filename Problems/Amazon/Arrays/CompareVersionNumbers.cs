namespace Problems.Amazon.Arrays;

public class CompareVersionNumbers
{
    public int CompareVersion(string version1, string version2)
    {
        var version1Split = version1.Split('.');
        var version2Split = version2.Split('.');

        int n = Math.Max(version1Split.Length, version2Split.Length);
        
        for (int i = 0; i < n; i++)
        {
            int group1 = (i < version1Split.Length) ? GetGroupVersion(version1Split[i]) : 0;
            int group2 = (i < version2Split.Length) ? GetGroupVersion(version2Split[i]) : 0;

            if (group1 < group2)
                return -1;
            if (group1 > group2)
                return 1;
        }
        
        return 0;
    }

    private int GetGroupVersion(string group)
    {
        int sum = 0;
        int indexOfNonZero = 0;

        while (indexOfNonZero < group.Length && group[indexOfNonZero] == '0')
            indexOfNonZero++;

        for (int i = indexOfNonZero; i < group.Length; i++)
        {
            var current = group[i] - '0';
            sum = (sum * 10) + current;
        }
        
        return sum;
    }
}