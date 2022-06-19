using System.Text;

namespace Problems.Google.String;

public static class AddStrings
{
    public static string Add(string num1, string num2)
    {
        var sb = new StringBuilder();

        var carry = 0;

        var num1Length = num1.Length - 1;
        var num2Length = num2.Length - 1;

        while (num1Length >= 0 || num2Length >= 0)
        {
            var x1 = num1Length >= 0 ? num1[num1Length] - '0' : 0;
            var x2 = num2Length >= 0 ? num2[num2Length] - '0' : 0;


            var sum = x1 + x2 + carry;
            carry = sum / 10;

            sb.Append(sum % 10);

            num1Length--;
            num2Length--;
        }

        if (carry != 0) sb.Append(carry);

        var res = sb.ToString().ToCharArray();
        System.Array.Reverse(res);
        return new string(res);
    }
}