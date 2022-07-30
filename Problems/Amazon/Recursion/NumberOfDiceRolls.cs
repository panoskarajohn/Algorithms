using Problems.Google.Recursion;

namespace Problems.Amazon.Recursion;

public class NumberOfDiceRolls
{
    private const int MODULO = 1_000_000_007;
    
    public int NumRollsToTarget(int n, int k, int target)
    {
        int[,] memo = new int[n + 1,target + 1];
        Fill(memo);
        var res = WaysToTarget(memo, 0, n, 0, target, k);
        return res;
    }

    private void Fill(int[,] memo, int value = -1)
    {
        for (int i = 0; i < memo.GetLength(0); i++)
        {
            for (int j = 0; j < memo.GetLength(1); j++)
            {
                memo[i, j] = value;
            }
        }
    }

    private int WaysToTarget(int[,] memo, int diceIndex, int n, int currentSum, int target, int k)
    {
        // all dices are visited
        if (diceIndex == n)
            return currentSum == target ? 1 : 0;

        if (memo[diceIndex, currentSum] != -1)
            return memo[diceIndex, currentSum];

        int ways = 0;
        for (int i = 1; i <= Math.Min(k, target - currentSum); i++)
        {
            ways = (ways + 
                    WaysToTarget(memo, diceIndex + 1, n, currentSum + i, target, k)) % MODULO;
        }

        memo[diceIndex, currentSum] = ways;
        return ways;
    }
}