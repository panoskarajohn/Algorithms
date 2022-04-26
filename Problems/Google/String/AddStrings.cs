using System.Text;
using Microsoft.VisualBasic;

namespace Problems.Google.String;

public static class AddStrings
{
    public static string Add(string num1, string num2)
    {
        var sb = new StringBuilder();

        int carry = 0;

        int num1Length = num1.Length - 1;
        int num2Length = num2.Length - 1;

        while (num1Length >= 0 || num2Length >= 0)
        {
            int x1 = num1Length >= 0 ? num1[num1Length] - '0' : 0;
            int x2 = num2Length >= 0 ? num2[num2Length] - '0' : 0;


            int sum = (x1 + x2 + carry);
            carry = sum / 10;

            sb.Append(sum % 10);
            
            num1Length--;
            num2Length--;
        }

        if (carry != 0)
        {
            sb.Append(carry);
        }

        var res = sb.ToString().ToCharArray();
        System.Array.Reverse(res);
        return new string(res);
    }
}