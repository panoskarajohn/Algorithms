namespace Problems.Heap;

public class FurthestBuildingYouCanReach
{
    private readonly Dictionary<(int, int, int), int> _cache = new();

    /// <summary>
    ///     Very nice solution
    /// </summary>
    /// <param name="heights"></param>
    /// <param name="bricks"></param>
    /// <param name="ladders"></param>
    /// <returns></returns>
    public int FurthestBuilding(int[] heights, int bricks, int ladders)
    {
        int n = heights.Length;
        var laddersUsed = new PriorityQueue<int, int>();
        for (int i = 0; i < n - 1; i++)
        {
            int climbed = heights[i + 1] - heights[i];
            if (climbed <= 0) continue;
            
            laddersUsed.Enqueue(climbed, climbed);
            if (laddersUsed.Count <= ladders)
                continue;

            bricks -= laddersUsed.Dequeue();
            if (bricks < 0)
                return i;
        }

        return n - 1;
    }

    /// <summary>
    /// There is a more optimal... this is actually N log^2 N
    /// Which is slower than the previous but the idea is that matters
    /// </summary>
    /// <param name="heights"></param>
    /// <param name="bricks"></param>
    /// <param name="ladders"></param>
    /// <returns></returns>
    public int FurthestBuilding_BS(int[] heights, int bricks, int ladders)
    {
        // Do a binary search of all the climbs we need to do to reach buildingIndex
        int low = 0;
        int high = heights.Length - 1;
        while (low < high)
        {
            int mid = low + (high - low + 1) / 2;
            if (IsReachable(mid, heights, bricks, ladders))
            {
                low = mid;
            }
            else
            {
                high = mid - 1;
            }
        }

        return low;
    }

    bool IsReachable(int buildingIndex, int[] heights, int bricks, int ladders)
    {
        // Make a list of all the climbs we need to do to reach buildingIndex
        var climbs = new List<int>();
        for (int i = 0; i < buildingIndex; i++)
        {
            var climb = heights[i + 1] - heights[i];
            if (climb < 0)
                continue;
            climbs.Add(climb);
        }
        
        climbs.Sort();

        // And now determine whether or not all of these climbs can be coverted with
        // the given bricks and ladders
        foreach (var climb in climbs)
        {
            //if there are bricks left, use those
            if (climb <= bricks)
            {
                bricks -= climb;
            }
            //otherwise, you'll have to use a ladder
            else if (ladders >= 1)
            {
                ladders--;
            }
            // and if there are no ladders either, we can't reach buildingIndex
            else
            {
                return false;
            }
        }
        
        return true;
    }


}