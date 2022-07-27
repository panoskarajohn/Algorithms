namespace Problems.Google.Sorting;

public class InsertInterval
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
       //define list
       var stack = new Stack<int[]>();
       int i = 0;
       int n = intervals.Length;

       //insert the new interval
       while (i <= n)
       {
           if (i == n || newInterval[0] <= intervals[i][0])
           {
               if (!stack.Any())
               {
                   stack.Push(newInterval);
               }
               else if (newInterval[0] <= stack.Peek()[1])
               {
                   //prev interval is in conflict with new interval
                   stack.Peek()[1] = Math.Max(stack.Peek()[1], newInterval[1]);
               }
               else
               {
                   stack.Push(newInterval);
               }

               break;
           }

           stack.Push(intervals[i]);
           i++;
       }
       
       //add the remaining
       for (int j = 0; j < n; j++)
       {
           int[] prev = stack.Peek();
           if (intervals[j][0] <= prev[1])
           {
               prev[1] = Math.Max(intervals[j][1], prev[1]);
           }
           else
           {
               stack.Push(intervals[j]);
           }
       }

       return stack
           .ToArray()
           .Reverse()
           .ToArray();


    }
    
}