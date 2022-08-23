namespace Problems.Heap;

public class KthSmallestElementInASortedMatrix
{
    public int KthSmallest(int[][] matrix, int k)
    {
        var pq = new PriorityQueue<int, int>();

        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                pq.Enqueue(matrix[i][j], -matrix[i][j]);
                if (pq.Count > k)
                    pq.Dequeue();
            }
        }

        return pq.Peek();

    }
}