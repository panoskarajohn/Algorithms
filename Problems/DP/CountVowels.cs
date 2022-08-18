namespace Problems.DP;

public class CountVowels
{
    private const int MODULO = 1_000_000_007;
    public int CountVowelPermutation(int n)
    {
        var aVowel = new long[n];
        var eVowel = new long[n];
        var iVowel = new long[n];
        var oVowel = new long[n];
        var uVowel = new long[n];

        aVowel[0] = 1;
        eVowel[0] = 1;
        iVowel[0] = 1;
        oVowel[0] = 1;
        uVowel[0] = 1;
        
        for (int i = 1; i < n; i++) {
            aVowel[i] = (eVowel[i - 1] + iVowel[i - 1] + uVowel[i - 1]) % MODULO;
            eVowel[i] = (aVowel[i - 1] + iVowel[i - 1]) % MODULO;
            iVowel[i] = (eVowel[i - 1] + oVowel[i - 1]) % MODULO;
            oVowel[i] = iVowel[i - 1] % MODULO;
            uVowel[i] = (iVowel[i - 1] + oVowel[i - 1]) % MODULO;
        }
        
        long result = 
            (aVowel[n - 1] + eVowel[n - 1] + iVowel[n - 1] + oVowel[n - 1] + uVowel[n - 1]) % MODULO;
        return (int)result;
    }
    
    
}