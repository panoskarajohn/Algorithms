namespace Problems.Array;

public static class MinimumSwaps
{
    /// <summary>
    ///     Returns minimum swaps that need to happen in order to sort an array.
    /// </summary>
    /// <remarks>Not optimal solution.</remarks>
    /// <param name="array"></param>
    /// <returns></returns>
    public static int Get(int[] array)
    {
        var n = array.Length;
        var swaps = 0;
        var i = 0;

        while (i < n)
        {
            if (i + 1 >= n)
                break; // we are on the last element

            var current = array[i];
            var next = array[i + 1];

            if (current > next)
            {
                var (index1, index2, indexToStart) = FindIndexToSwap(array, i);
                (array[index1], array[index2]) = (array[index2], array[index1]);
                swaps++;
                i = indexToStart - 1; // due to incrementing it later
            }

            i++; // increment i
        }

        return swaps;
    }

    private static (int index1, int index2, int startingIndex) FindIndexToSwap(int[] array, int currentIndex)
    {
        var current = array[currentIndex]; // we are sure that current is larger that next
        var next = array[currentIndex + 1];

        if (currentIndex == 0)
            return (currentIndex, 1, 0);

        for (var i = 0; i < currentIndex; i++)
            if (next <= array[i])
                return (i, currentIndex + 1, currentIndex - 1);

        var n = array.Length;
        for (var i = currentIndex + 2; i < n; i++) // this means we need to swap with the larger number
        {
            if (i + 1 >= n)
                return (currentIndex, currentIndex + 1, n - 2);

            if (current > array[i] && array[i] < array[i + 1])
            {
                if (next < array[i])
                    return (currentIndex, currentIndex + 1, currentIndex);

                return (currentIndex, i, currentIndex);
            }
        }

        return (currentIndex, currentIndex + 1, 0);
    }
}