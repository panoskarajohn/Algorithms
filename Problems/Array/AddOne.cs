namespace Problems.Array;

public static class AddOne
{
    public static int[] Execute(int[] digits)
    {
        var n = digits.Length;

        if (digits[n - 1] < 9)
        {
            digits[n - 1]++;
            return digits;
        }


        var remainder = 1;
        for (var i = digits.Length - 1; i >= 0; i--)
        {
            digits[i] += remainder;

            if (digits[i] == 10)
            {
                digits[i] = 0;
                remainder = 1;
            }
            else
            {
                remainder = 0;
            }
        }

        if (remainder == 1)
        {
            var array = new int[n + 1];
            array[0] = remainder;
            for (var i = 1; i < n + 1; i++) array[i] = digits[i - 1];

            return array;
        }

        return digits;
    }
}