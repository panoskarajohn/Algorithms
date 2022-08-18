namespace Problems.Series.PaintHouse;

public class PaintHouseTwo
{
    public int MinCost(int[][] costs)
    {
        if (costs is null || costs.Length == 0)
            return 0;

        var n = costs.Length;
        var k = costs[0].Length;

        for (var house = 1; house < n; house++)
        {
            var minColor = -1;
            var minSecondColor = -1;

            for (var color = 0; color < k; color++)
            {
                var currentCost = costs[house - 1][color];
                if (minColor == -1 || currentCost < costs[house - 1][minColor])
                {
                    minSecondColor = minColor;
                    minColor = color;
                }
                else if (minSecondColor == -1 || currentCost < costs[house - 1][minSecondColor])
                {
                    minSecondColor = color;
                }
            }

            for (var color = 0; color < k; color++)
                if (color == minColor)
                    costs[house][color] += costs[house - 1][minSecondColor];
                else
                    costs[house][color] += costs[house - 1][minColor];
        }


        return costs[^1].Min();
    }
}