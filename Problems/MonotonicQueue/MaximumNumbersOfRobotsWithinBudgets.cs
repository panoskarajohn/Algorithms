namespace Problems.MonotonicQueue;

public class MaximumNumbersOfRobotsWithinBudgets
{
    public int MaximumRobots(int[] chargeTimes, int[] runningCosts, long budget)
    {
        var max = int.MinValue;
        var n = chargeTimes.Length;
        var left = 0;
        var right = n - 1;

        while (left < right)
        {
            var subCharge = chargeTimes[left..right];
            var subRunningCosts = runningCosts[left..right];
            long k = chargeTimes.Length;

            var totalCost = subCharge.Max() + k * subRunningCosts.Sum();

            if (totalCost <= budget)
                if (right - left + 1 > max)
                    max = right - left + 1;

            if (runningCosts[left] + chargeTimes[left] < runningCosts[right] + chargeTimes[right])
                right--;
            else
                left++;
        }

        return max == int.MinValue ? 0 : max;
    }
}