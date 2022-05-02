namespace Problems.Google.Arrays;

public static class MeetingRooms
{
    public static bool CanAttendMeetings(int[][] intervals)
    {
        var comparer = Comparer<int>.Default;
        System.Array.Sort(intervals, (a, b) => comparer.Compare(a[1], b[1]));

        for (int i = 0; i < intervals.Length - 1; i++)
        {
            if (i + 1 > intervals.Length)
                break;
                
            var firstInterval = intervals[i];
            var secondInterval = intervals[i + 1];

            var canAttendMeeting = firstInterval[1] <= secondInterval[0];
            if (!canAttendMeeting)
                return false;
        }
        return true;
    }

    public static int GetRooms(int[][] intervals)
    {
        if (intervals is null || intervals.Length == 0)
            return 0;
        
        var comparer = Comparer<int>.Default;
        System.Array.Sort(intervals, (a, b) => comparer.Compare(a[0], b[0]));
        PriorityQueue<int, int> heap = new PriorityQueue<int, int>();
        
        heap.Enqueue(intervals[0][1], intervals[0][1]);

        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] >= heap.Peek())
            {
                heap.Dequeue();
            }
            heap.Enqueue(intervals[i][1], intervals[i][1]);
        }
        
        return heap.Count;

    }
}