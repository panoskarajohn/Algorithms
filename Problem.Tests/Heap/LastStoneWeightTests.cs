using FluentAssertions;
using Problems.Heap;

namespace Problem.Tests.Heap;

public class LastStoneWeightTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Last_Stone_Weight_Tests(int[] stones, int expected)
    {
        var result = new FindLastStoneWeight().Get(stones);
        result.Should().Be(expected);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new int[] { 2,7,4,1,8,1 },
                    1
                }
            };
        }
    }
}