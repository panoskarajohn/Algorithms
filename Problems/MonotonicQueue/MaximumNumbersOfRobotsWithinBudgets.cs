namespace Problems.MonotonicQueue;

public class MaximumNumbersOfRobotsWithinBudgets
{
    public int MaximumRobots(int[] chargeTimes, int[] runningCosts, long budget)
    {
        var max = int.MinValue;
        var n = chargeTimes.Length;
        var left = 0;
        var right = 0;

        var queue = new LinkedList<int>();
        var count = 0;
        var currentSum = 0L;

        while (right < n)
        {
            currentSum += runningCosts[right];
            count++;
            while (queue.Any() && queue.Last!.Value < chargeTimes[right])
                queue.RemoveLast();

            queue.AddLast(chargeTimes[right]);

            var cost = queue.First!.Value + count * currentSum;

            while (cost > budget)
            {
                currentSum -= runningCosts[left];
                count--;
                if (queue.Any() && queue.First.Value == chargeTimes[left])
                    queue.RemoveFirst();
                left++;
                if (count == 0)
                    break;

                cost = queue.First.Value + count * currentSum;
            }

            max = Math.Max(max, count);
            right++;
        }

        return max;
    }
}