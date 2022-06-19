namespace Problems.Google.Arrays;

public class MaximizeDistanceToClosestPerson
{
    public static int Get(int[] seats)
    {
        var lastPerson = -1;
        var max = -1;

        for (var i = 0; i < seats.Length; i++)
            if (seats[i] == 1)
            {
                if (lastPerson != -1)
                    max = Math.Max(max, (i - lastPerson) / 2);
                else
                    max = Math.Max(max, i);
                lastPerson = i;
            }

        if (seats[seats.Length - 1] == 0) max = Math.Max(max, seats.Length - lastPerson - 1);


        return max;
    }
}