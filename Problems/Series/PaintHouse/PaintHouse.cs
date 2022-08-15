namespace Problems.Series.PaintHouse;

public class PaintHouse
{
    public int MinCost(int[][] costs)
    {
        if (costs is null || costs.Length == 0)
            return 0;

        int min = int.MinValue;
        for (int i = 1; i < costs.Length; i++)
        {
            costs[i][0] += Math.Min(costs[i - 1][1], costs[i - 1][2]);
            costs[i][1] += Math.Min(costs[i - 1][0], costs[i - 1][2]);
            costs[i][2] += Math.Min(costs[i - 1][0], costs[i - 1][1]);
        }

        return costs[^1].Min();

    }
}



