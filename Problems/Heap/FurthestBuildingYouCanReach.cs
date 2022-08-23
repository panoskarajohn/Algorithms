namespace Problems.Heap;

public class FurthestBuildingYouCanReach
{
    private readonly Dictionary<(int, int, int), int> _cache = new();

    /// <summary>
    ///     Of course Dfs solutoin out of memory
    /// </summary>
    /// <param name="heights"></param>
    /// <param name="bricks"></param>
    /// <param name="ladders"></param>
    /// <returns></returns>
    public int FurthestBuilding(int[] heights, int bricks, int ladders)
    {
        return Dfs(0, bricks, ladders, heights);
    }

    private int Dfs(int index, int bricks, int ladders, int[] heights)
    {
        if ((bricks < 0 && ladders < 0) || index == heights.Length - 1) return index;

        if (_cache.ContainsKey((index, bricks, ladders)))
            return _cache[(index, bricks, ladders)];

        var currentHeight = heights[index];
        var nextHeight = heights[index + 1];

        var countSteps = 0;
        var countStepsWithBricks = 0;
        var countStepsWithLadders = 0;
        if (currentHeight >= nextHeight)
        {
            countSteps = Dfs(index + 1, bricks, ladders, heights);
        }
        else
        {
            countStepsWithBricks = bricks - (nextHeight - currentHeight) >= 0
                ? Dfs(index + 1, bricks - (nextHeight - currentHeight), ladders, heights)
                : 0;

            countStepsWithLadders = ladders - 1 >= 0
                ? Dfs(index + 1, bricks, ladders - 1, heights)
                : 0;
        }

        var max = Math.Max(Math.Max(countSteps, index), Math.Max(countStepsWithBricks, countStepsWithLadders));
        return _cache[(index, bricks, ladders)] = max;
    }
}