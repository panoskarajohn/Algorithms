using FluentAssertions;

namespace Problem.Tests.Amazon.Sorting;

public class TopKFrequentElementsTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Top_k_frequent_elements_tests(int[] data, int k, int[] expected)
    {
        var result = new TopKFrequentElements().TopKFrequent(data, k);
        result.Should().BeEquivalentTo(expected);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {1,1,1,2,2,3},
                    2,
                    new[] {1,2},
                }
            };
        }
    }
}

public class TopKFrequentElements
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var dic = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (!dic.ContainsKey(num))
                dic[num] = 0;
            dic[num]++;
        }
        
        var pq = new PriorityQueue<int, int>();
        foreach (var el in dic)
        {
            pq.Enqueue(el.Key, -el.Value);
        }

        var result = new int[k];
        for (int i = 0; i < k; i++)
            result[i] = pq.Dequeue();
        return result;
    }
}