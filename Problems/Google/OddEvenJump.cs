using System.Reflection.Metadata;

namespace Problems.Google;

public static class OddEvenJump
{
    public static int OddEvenJumps(int[] arr)
    {
        int count = 0;
        
        int n = arr.Length;
        if(n==0)
            return count;
        
        bool[] higher = new bool[n];
        bool[] lower = new bool[n];
        int [] nextHighers = GetNextJumps(arr, true);
        int [] nextLowers = GetNextJumps(arr, false);
        
        higher[n-1] = true;
        lower[n-1] = true;
        count++;
        
        for(int i=n-2;i>=0;i--){
            int hi = nextHighers[i];
            int low = nextLowers[i];
            
            if(hi > -1) higher[i] = lower[hi];
            if(low > -1) lower[i] = higher[low];
            
            if(higher[i])
                count++;
        }
         
        return count;

    }
    
    private static int[] GetNextJumps(int[] arr, bool high){
        int[] next = new int[arr.Length];
        
        var sortedList = arr.Select((x, i) => new KeyValuePair<int, int>(x, i));
        
        if(high)
            sortedList = sortedList
                .OrderBy(x => x.Key)
                .ThenBy(x => x.Value)
                .ToList();
        else
            sortedList = sortedList
                .OrderByDescending(x => x.Key)
                .ThenBy(x => x.Value)
                .ToList();
                            
        Stack<int> stack = new Stack<int>();
        foreach (var kv in sortedList)
        {
            while (stack.Count > 0 && stack.Peek() < kv.Value)
                next[stack.Pop()] = kv.Value;
            stack.Push(kv.Value);
        }
        return next;
    }
}