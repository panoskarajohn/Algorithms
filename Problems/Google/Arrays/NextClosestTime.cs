namespace Problems.Google.Arrays;

public class NextClosestTime
{
    public static string Get(string time)
    {
        int minutes = (int.Parse(time.Substring(0,2)) * 60) + int.Parse(time.Substring(3));

        var digits = new HashSet<int>();

        foreach (var t in time)
        {
            int current = t - '0';
            digits.Add(current);
        }

        while (true)
        {
            minutes = (minutes + 1) % (24 * 60);
            int[] nextTime = {minutes / 60 / 10, minutes / 60 % 10, minutes % 60 / 10, minutes % 60 % 10};

            bool isValid = true;
            foreach (var digit in nextTime)
            {
                if (!digits.Contains(digit))
                    isValid = false;
            }

            if (isValid) return $"{(minutes / 60):D2}:{(minutes % 60):D2}";
        }
    }
    


}