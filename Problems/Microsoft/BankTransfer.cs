namespace Problems.Microsoft;

public class BankTransfer
{
    /// <summary>
    /// Given a series of transactions from bank A to bank B
    /// Provide the minimum balance for bank A and bank B
    /// so that they do not go bankrupt. Their balance does not go < 0
    /// </summary>
    /// <param name="R">ABBAABBAB</param>
    /// <param name="V">242368219</param>
    /// <returns></returns>
    public int[] InitialAmount(string R, int[] V)
    {
        int minA = 0;
        int minB = 0;
        int balance = 0;
        int n = R.Length;

        for (int i = 0; i < n; i++)
        {
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
        }

        return new[] {-minA, -minB};
    }
}