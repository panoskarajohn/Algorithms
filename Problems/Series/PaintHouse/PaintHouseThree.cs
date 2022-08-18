namespace Problems.Series.PaintHouse;

public class PaintHouseThree
{
    private const int MaxCost = 1_000_001;
    private int[][][] _memo;

    #region TopDown

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

    #region Bottom up

    public int MinCostBottomUp(int[] houses, int[][] costs, int m, int n, int target)
    {
        FillMemo(m - 1, target, n - 1);
        
        //initialize memo array with max cost
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j <= target; j++)
            {
                System.Array.Fill(_memo[i][j], MaxCost);
            }
        }

        for (int color = 1; color <= n; color++)
        {
            if (houses[0] == color)
            {
                // if the house has same color, no cost
                _memo[0][1][color - 1] = 0;
            }
            else if(houses[0] == 0)
            {
                _memo[0][1][color - 1] = costs[0][color - 1];
            }
        }

        for (int house = 1; house < m; house++)
        {
            for (int neighborhoods = 1; neighborhoods <= Math.Min(target, house + 1); neighborhoods++)
            {
                for (int color = 1; color <= n; color++)
                {
                    if (houses[house] != 0 && color != houses[house])
                    {
                        continue;
                    }

                    int currentCost = MaxCost;
                    
                    //iterate over all the possible color for previous house
                    for (int prevColor = 1; prevColor <= n; prevColor++)
                    {
                        if (prevColor != color)
                        {
                            // decrement the neighborhood as adjacent houses have different color
                            currentCost = Math.Min(currentCost, _memo[house - 1][neighborhoods - 1][prevColor - 1]);
                        }
                        else
                        {
                            currentCost = Math.Min(currentCost, _memo[house - 1][neighborhoods][color - 1]);
                        }
                    }
                    
                    //if the house is already painted, cost to paint is 0
                    int costToPaint = houses[house] != 0 ? 0 : costs[house][color - 1];
                    _memo[house][neighborhoods][color - 1] = currentCost + costToPaint;
                }
            }
        }

        int min = MaxCost;
        
        // Find the minimum cost with m houses and target neighborhoods
        // By comparing cost for different color for the last house
        for (int color = 1; color <= n; color++) {
            min = Math.Min(min, _memo[m - 1][target][color - 1]);
        }

        return min == MaxCost ? -1 : min;
    }

    #endregion
}