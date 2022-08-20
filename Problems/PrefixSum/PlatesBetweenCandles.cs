namespace Problems.PrefixSum;

public class PlatesBetweenCandles
{
    /// <summary>
    ///     Using prefix sum
    /// </summary>
    /// <param name="s"></param>
    /// <param name="queries"></param>
    /// <returns></returns>
    public int[] Count(string s, int[][] queries)
    {
        /*
         * Brainstorming
         * Example:
         *  0 1 2 3 4 5 6 7 8 9
         *  * * | * | * * * * |
         *  1 2 2 3 3 4 5 6 7 7 <- Prefix sum
         */


        var n = s.Length;

        var prefixSum = new int[n];
        var candleLeft = new int[n];
        var candleRight = new int[n];

        prefixSum[0] = s[0] == '*' ? 1 : 0;
        candleLeft[0] = s[0] == '|' ? 0 : -1;

        for (var i = 1; i < n; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + (s[i] == '*' ? 1 : 0);
            candleLeft[i] = s[i] == '|' ? i : candleLeft[i - 1];
        }

        candleRight[n - 1] = s[n - 1] == '|' ? n - 1 : n;

        for (var i = n - 2; i >= 0; i--) candleRight[i] = s[i] == '|' ? i : candleRight[i + 1];

        var result = new int[queries.Length];
        for (var i = 0; i < queries.Length; i++)
        {
            /*
             * 0 1 2 3 4 5 6 7 8 9
             * * * | * | * * * * |
             * 1 2 2 3 3 4 5 6 7 8 <- prefix sum
             * There is a special case when we get 5 - 8
             * which should return 0
             * In that case our start will be 9 and end will be 4
             * 
             */
            var start = candleRight[queries[i][0]];
            var end = candleLeft[queries[i][1]];

            result[i] = start > end ? 0 : prefixSum[end] - prefixSum[start];
        }

        return result;
    }
}