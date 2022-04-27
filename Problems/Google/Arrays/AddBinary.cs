using System.Text;

namespace Problems.Google.Arrays;

public static class AddBinary
{
    public static string Add(string a, string b)
    {
        var sb = new StringBuilder();
        int aLength = a.Length - 1;
        int bLength = b.Length - 1;
        int carry = 0; 

        while (aLength >= 0 || bLength >= 0)
        {
            var x1 = aLength >= 0 ? a[aLength] - '0' : 0;
            var x2 = bLength >= 0 ? b[bLength] - '0' : 0;

            int sum = carry + x1 + x2;

            sb.Append(sum % 2);
            carry = sum / 2;
            
            aLength--;
            bLength--;
        }

        if (carry != 0)
            sb.Append(carry);

        var res = sb.ToString().ToCharArray();
        System.Array.Reverse(res);
        return new string(res);
    }
}