namespace Problems.DP.HouseRobber;

public class HouseRobber
{
    public int Rob(int[] houses)
    {
        var n = houses.Length;
        var dp = new int[n];

        dp[0] = houses[0];
        dp[1] = Math.Max(houses[0], houses[1]);
        for (var i = 2; i < n; i++)
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + houses[i]);

        return dp[^1];
    }

    public int RobTwoValues(int[] houses)
    {
        int rob1 = 0, rob2 = 0;

        for (var i = 0; i < houses.Length; i++)
        {
            var temp = Math.Max(houses[i] + rob1, rob2);
            rob1 = rob2;
            rob2 = temp;
        }

        return rob2;
    }
}