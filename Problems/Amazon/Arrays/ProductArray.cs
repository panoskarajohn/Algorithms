namespace Problems.Amazon.Arrays;

public class ProductArray
{
    public int[] GetExceptSelf(int[] values)
    {
        var n = values.Length;

        var prefixProduct = new int[n];
        var suffixProduct = new int[n];

        for (var i = 0; i < n; i++)
        {
            var previousIndex = i - 1;
            var prefix = previousIndex < 0 ? 1 : prefixProduct[i - 1];
            var previous = previousIndex < 0 ? 1 : values[i - 1];

            prefixProduct[i] = prefix * previous;
        }

        for (var i = n - 1; i >= 0; i--)
        {
            var nextIndex = i + 1;
            var suffix = nextIndex >= n ? 1 : suffixProduct[i + 1];
            var next = nextIndex >= n ? 1 : values[i + 1];

            suffixProduct[i] = suffix * next;
        }

        var result = new int[n];

        for (var i = 0; i < n; i++) result[i] = prefixProduct[i] * suffixProduct[i];

        return result;
    }

    /// <summary>
    ///     O(1) space
    ///     result array does not count
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public int[] GetExceptSelfOptimized(int[] values)
    {
        var n = values.Length;
        Span<int> result = stackalloc int[n];

        for (var i = 0; i < n; i++)
        {
            var previousIndex = i - 1;
            var prefix = previousIndex < 0 ? 1 : result[previousIndex];
            var previous = previousIndex < 0 ? 1 : values[previousIndex];

            result[i] = prefix * previous;
        }

        var right = 1;
        for (var i = n - 1; i >= 0; i--)
        {
            result[i] *= right;
            right *= values[i];
        }

        return result.ToArray();
    }
}