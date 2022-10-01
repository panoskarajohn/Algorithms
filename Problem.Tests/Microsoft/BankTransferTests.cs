using FluentAssertions;
using Problems.Microsoft;

namespace Problem.Tests.Microsoft;

public class BankTransferTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    "BAABA",
                    new int[] { 2,4,1,1,2 },
                    new int[] { 2, 4 }
                },
                new object[]
                {
                    "ABAB",
                    new int[] { 10,5,10,15 },
                    new int[] { 0, 15 }
                },
                new object[]
                {
                    "B",
                    new int[] { 100 },
                    new int[] { 100, 0 }
                },
                
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Bank_Transfer_Tests(string R, int[] V, int[] expected)
    {
        var result = new BankTransfer().InitialAmount(R, V);
        result.Should().BeEquivalentTo(expected);
    }
}