using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.GraphsTrees;
using Xunit;

namespace Problem.Tests.Google.GraphsTrees;

public class ReconstructItineraryTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Reconstruct_Itinerary_Tests(IList<IList<string>> data, IList<string> expected)
    {
        var actual = new ReconstructItinerary().FindItinerary(data);
        actual.Should().BeEquivalentTo(expected);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new List<IList<string>>()
                    {
                        new List<string>() { "MUC", "LHR" },
                        new List<string>() { "JFK", "MUC" },
                        new List<string>() { "SFO", "SJC" },
                        new List<string>() { "LHR", "SFO" }
                        
                    },
                    new List<string>() { "JFK", "MUC", "LHR", "SFO", "SJC" }
                },
                new object[]
                {
                    new List<IList<string>>()
                    {
                        new List<string>() { "JFK", "SFO" },
                        new List<string>() { "JFK", "ATL" },
                        new List<string>() { "SFO", "ATL" },
                        new List<string>() { "ATL", "JFK" },
                        new List<string>() { "ATL", "SFO" }
                    },
                    new List<string>() { "JFK", "ATL", "JFK", "SFO", "ATL", "SFO" }
                },
            };
        }
    }
}