namespace Problems.Heap;

public class FindKWeakestRow
{
    public int[] KWeakestRows(int[][] mat, int k)
    {
        var rows = mat.Length;
        var matPairs = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            matPairs[i] = new int[2];
        }

        for (int i = 0; i < rows; i++)
        {
            var soldiers = 0;
            for (int j = 0; j < mat[i].Length; j++)
            {
                if(mat[i][j] == 0) break;
                soldiers++;
            }

            matPairs[i][0] = soldiers;
            matPairs[i][1] = i;
        }
        
        System.Array.Sort(matPairs, (a, b) =>
        {
            if (a[0] == b[0])
            {
                return a[1].CompareTo(b[1]);
            }

            return a[0].CompareTo(b[0]);
        });

        int[] indexes = new int[k];

        for (int i = 0; i < k; i++)
        {
            indexes[i] = matPairs[i][1];
        }

        return indexes;

    }

    
}