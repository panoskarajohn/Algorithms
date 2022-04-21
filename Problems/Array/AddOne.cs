using System.Numerics;

namespace Problems.Array;

public static class AddOne
{
    public static int[] Execute(int[] digits)
    {
        int n = digits.Length;
        
        if (digits[n - 1] < 9)
        {
            digits[n - 1]++;
            return digits;
        }


        int remainder = 1;
        for (int i = digits.Length - 1; i >= 0; i--)
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
            for (int i = 1; i < n + 1; i++)
            {
                array[i] = digits[i - 1];
            }

            return array;
        }

        return digits;

    }
}