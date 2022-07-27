namespace Problems.Google.Sorting;

public class MergeIntervals
{
    public int[][] Merge(int[][] intervals)
    {
        var result = new Stack<int[]>();

        if (intervals is null)
            return result.ToArray();

        if (intervals.Length == 1)
        {
            result.Push(intervals[0]);
            return result.ToArray();
        }

        var comparer = Comparer<int>.Default;
        //array based on the first value
        System.Array.Sort(intervals, (a, b)
            => comparer.Compare(a[0], b[0]));

        result.Push(intervals[0]);
        for (var i = 1; i < intervals.Length; i++)
        {
            var current = result.Peek();
            var next = intervals[i];

            var nextZeroIsInRangeFromNext = current[1] >= next[0] && current[1] <= next[1];
            var nextIsLargerThanCurrent = current[1] >= next[0] && current[1] >= next[1];

            if (nextZeroIsInRangeFromNext)
            {
                result.Pop();
                result.Push(new[] {current[0], next[1]});
            }
            else if (nextIsLargerThanCurrent)
            {
                result.Pop();
                result.Push(new[] {current[0], current[1]});
            }
            else
            {
                result.Push(next);
            }
        }

        return result.ToArray().Reverse().ToArray();
    }
}