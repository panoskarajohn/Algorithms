namespace Problems.Series.PaintHouse;

public class PaintHouseThree
{
    private int[][][] _memo;

    #region TopDown

    private const int MaxCost = 1_000_001;

    public int MinCostTopDown(int[] houses, int[][] costs, int m, int n, int target)
    {
        _memo = FillMemo(m, target, n);
        var answer = FindMinCost(houses, costs, target, 0, 0, 0);
        return answer == MaxCost ? -1 : answer;
    }

    private int FindMinCost(int[] houses, int[][] cost, int targetCount, int currentIndex, int neighborhoodCount,
        int previousHouseColor)
    {
        if (currentIndex == houses.Length)
            return neighborhoodCount == targetCount ? 0 : MaxCost;

        if (neighborhoodCount > targetCount)
            return MaxCost;
        if (_memo[currentIndex][neighborhoodCount][previousHouseColor] != 0)
            return _memo[currentIndex][neighborhoodCount][previousHouseColor];

        var minCost = MaxCost;
        if (houses[currentIndex] != 0)
        {
            var newNeighborhoodCount = neighborhoodCount + (houses[currentIndex] != previousHouseColor ? 1 : 0);
            minCost = FindMinCost(houses, cost, targetCount, currentIndex + 1, newNeighborhoodCount,
                houses[currentIndex]);
        }
        else
        {
            var totalColors = cost[0].Length;

            for (var color = 1; color <= totalColors; color++)
            {
                var newNeighborhoodCount = neighborhoodCount + (color != previousHouseColor ? 1 : 0);
                var currentCost = cost[currentIndex][color - 1] + FindMinCost(houses, cost, targetCount,
                    currentIndex + 1, newNeighborhoodCount, color);
                minCost = Math.Min(minCost, currentCost);
            }
        }

        _memo[currentIndex][neighborhoodCount][previousHouseColor] = minCost;
        return minCost;
    }

    private int[][][] FillMemo(int m, int target, int n)
    {
        _memo = new int[m + 1][][];
        for (var i = 0; i <= m; i++)
        {
            _memo[i] = new int[target + 1][];
            for (var j = 0; j <= target; j++) _memo[i][j] = new int[n + 1];
        }

        return _memo;
    }

    #endregion
}