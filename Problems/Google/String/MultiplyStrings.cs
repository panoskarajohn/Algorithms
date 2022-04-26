using System.Text;

namespace Problems.Google.String;

public static class MultiplyStrings
{
    public static string Multiply(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0")
            return "0";
        
        var sb = new StringBuilder();
        int num1Length = num1.Length - 1;
        var listOfMultiplication = new List<string>();
        int placement = 0;

        while (num1Length >= 0)
        {
            char currentDigit = num1[num1Length];
            listOfMultiplication.Add(MultiplyWithDigit(num2, currentDigit, placement++));
            num1Length--;
        }

        string sum = "0";

        foreach (var numbers in listOfMultiplication)
        {
            sum = AddStrings.Add(sum, numbers);
        }

        return sum;
    }

    private static string MultiplyWithDigit(string secondNumber, char digit, int placement)
    {
        var sb = new StringBuilder();

        
        for (int i = 0; i < placement; i++)
            sb.Append(0);
        

        int carry = 0;
        int x1 = digit - '0';
        int secondNumberLength = secondNumber.Length - 1;

        while (secondNumberLength >= 0)
        {
            int x2 = secondNumber[secondNumberLength] - '0';
            int sum = (x1 * x2) + carry;

            sb.Append(sum % 10);
            carry = sum / 10;
            secondNumberLength--;
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