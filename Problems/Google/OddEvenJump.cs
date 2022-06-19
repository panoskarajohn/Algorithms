namespace Problems.Google;

public static class OddEvenJump
{
    public static int OddEvenJumps(int[] arr)
    {
        var count = 0;

        var n = arr.Length;
        if (n == 0)
            return count;

        var higher = new bool[n];
        var lower = new bool[n];
        var nextHighers = GetNextJumps(arr, true);
        var nextLowers = GetNextJumps(arr, false);

        higher[n - 1] = true;
        lower[n - 1] = true;
        count++;

        for (var i = n - 2; i >= 0; i--)
        {
            var hi = nextHighers[i];
            var low = nextLowers[i];

            if (hi > -1) higher[i] = lower[hi];
            if (low > -1) lower[i] = higher[low];

            if (higher[i])
                count++;
        }

        return count;
    }

    private static int[] GetNextJumps(int[] arr, bool high)
    {
        var next = new int[arr.Length];

        var sortedList = arr.Select((x, i) => new KeyValuePair<int, int>(x, i));

        if (high)
            sortedList = sortedList
                .OrderBy(x => x.Key)
                .ThenBy(x => x.Value)
                .ToList();
        else
            sortedList = sortedList
                .OrderByDescending(x => x.Key)
                .ThenBy(x => x.Value)
                .ToList();

        var stack = new Stack<int>();
        foreach (var kv in sortedList)
        {
            while (stack.Count > 0 && stack.Peek() < kv.Value)
                next[stack.Pop()] = kv.Value;
            stack.Push(kv.Value);
        }

        return next;
    }
}