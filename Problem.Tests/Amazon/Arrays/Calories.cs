using FluentAssertions;

namespace Problem.Tests.Amazon.Arrays;

public class CaloriesTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Calories_tests(int[] calories, int k, int lower, int upper, int points)
    {
        var res = new Calories().GetPoints(calories, k, lower, upper);
        res.Should().Be(points);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                   new int[] { 1,2,3,4,5 }, 
                   1, 
                   3,
                   3,
                   0
                },
                new object[]
                {
                    new int[] { 6,13,8,7,10,1,12,11 }, 
                    6, 
                    5,
                    37,
                    3
                }
            };
        }
    }
}

public class Calories
{
    public int GetPoints(int[] calories, int k, int lower, int upper)
    {
        int points = 0;
        int n = calories.Length;
        int kk = 0;
        int sum = 0;
        
        for(int i = 0; i < n; i++)
        {
            if(i + k - 1 >= n)
                continue;
            while(kk < k)
            {
                sum += calories[i + kk];
                kk++;
            }
            
            if(sum < lower)
                points--;
            else if(sum > upper)
                points++;
            
            kk = 0;
            sum = 0;
        }
        
        return points;
    }
}