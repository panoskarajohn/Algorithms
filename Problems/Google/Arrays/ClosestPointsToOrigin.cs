namespace Problems.Google.Arrays;

public class ClosestPointsToOrigin
{
    public static int[][] KClosest(int k, int[][] points)
    {
        //TElement is the point, and the priority is the distance
        var heap = new PriorityQueue<int[], double>();
        var returnArray = new int[k][];
        int x2 = 0;
        int y2 = 0;

        for (int i = 0; i < points.Length; i++)
        {
            var x1 = points[i][0];
            var y1 = points[i][1];

            var euklidean = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            heap.Enqueue(points[i], euklidean);
        }

        while (k > 0)
        {
            returnArray[k - 1] = heap.Dequeue();
            k--;
        }


        return returnArray;
    }
}