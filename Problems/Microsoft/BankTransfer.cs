namespace Problems.Microsoft;

public class BankTransfer
{
    /// <summary>
    ///     Given a series of transactions from bank A to bank B
    ///     Provide the minimum balance for bank A and bank B
    ///     so that they do not go bankrupt. Their balance does not go < 0
    /// </summary>
    /// <param name="R">ABBAABBAB</param>
    /// <param name="V">242368219</param>
    /// <returns></returns>
    public int[] InitialAmount(string R, int[] V)
    {
        var minA = 0;
        var minB = 0;
        var balance = 0;
        var n = R.Length;

        for (var i = 0; i < n; i++)
            if (R[i] == 'A')
            {
                balance += V[i];
                minB = Math.Min(-balance, minB);
            }
            else
            {
                balance -= V[i];
                minA = Math.Min(balance, minA);
            }

        return new[] {-minA, -minB};
    }

    public int[] InitialAmountNotOptimal(string R, int[] V)
    {
        var minA = 0;
        var minB = 0;

        while (true)
        {
            var result = DoTransactions(R, V, minA, minB);

            if (result[0] < 0)
                minA++;
            if (result[1] < 0)
                minB++;

            if (result[0] >= 0 && result[1] >= 0)
                return new[] {minA, minB};
        }
    }

    private int[] DoTransactions(string R, int[] V, int bA, int bB)
    {
        var n = R.Length;
        for (var i = 0; i < n; i++)
        {
            if (R[i] == 'A')
            {
                bB -= V[i];
                bA += V[i];
            }
            else
            {
                bA -= V[i];
                bB += V[i];
            }

            if (bA < 0 || bB < 0)
                return new[] {bA, bB};
        }

        return new[] {bA, bB};
    }
}