using FluentAssertions;
using Problems.Contests;

namespace Problem.Tests.Contest;

public class MergeSimilarItemTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Merge_similar_item_tests(int[][] items1, int[][] items2, IList<IList<int>> expexted)
    {
        var result = new MergeSimilarItems().Merge(items1, items2);
        result.Should().BeEquivalentTo(expexted);

    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new int[][] { new []{1,1}, new []{4,5}, new []{3,8} },
                    new int[][] { new []{3,1}, new []{1,5}},
                    new List<IList<int>>
                    {
                        new List<int>() { 1,6 },
                        new List<int>() { 3,9 },
                        new List<int>() { 4,5 }
                    }
                },
            };
        }
    }
}