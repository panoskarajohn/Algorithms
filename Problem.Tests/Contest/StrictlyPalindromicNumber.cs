using FluentAssertions;

namespace Problem.Tests.Contest;

public class StrictlyPalindromicNumber
{
    public bool IsStrictlyPalindromic(int n) {
        for(int baseC = 2; baseC * baseC <= n; baseC++)
        {
            var c = ConvertToBase(n, baseC);
            System.Array.Reverse(c);
            var r = new string(c);
            if(!c.Equals(r))
                return false;
        }
        
        return true;
    }
    
    char[] ConvertToBase(int current, int numberBase)
    {
        int size = current / numberBase;
        var arr = new char[size];
        for(int i = 0; i < size; i++)
        {
            arr[i] = (char)(current % numberBase);
            current /= numberBase;
        }
        
        return arr;
    }
}

public class StrictlyPalindromicNumberTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    9, false
                },
                new object[]
                {
                    4, false
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Strictly_palindromic_number_tests(int n, bool expected)
    {
        var result = new StrictlyPalindromicNumber().IsStrictlyPalindromic(n);
        result.Should().Be(expected);
    }
}