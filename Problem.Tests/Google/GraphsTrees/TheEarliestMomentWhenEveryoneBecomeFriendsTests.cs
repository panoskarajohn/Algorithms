using System.Collections.Generic;
using FluentAssertions;
using Problems.Google.GraphsTrees;

namespace Problem.Tests.Google.GraphsTrees;

public class TheEarliestMomentWhenEveryoneBecomeFriendsTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new[] {new[] {0, 2, 0}, new[] {1, 0, 1}, new[] {3, 0, 3}, new[] {4, 1, 2}, new[] {7, 3, 1}},
                    4,
                    3
                },
                new object[]
                {
                    new[]
                    {
                        new[] {20190101, 0, 1},
                        new[] {20190104, 3, 4},
                        new[] {20190107, 2, 3},
                        new[] {20190211, 1, 5},
                        new[] {20190224, 2, 4},
                        new[] {20190301, 0, 3},
                        new[] {20190312, 1, 2},
                        new[] {20190322, 4, 5}
                    },
                    6,
                    20190301
                },
                new object[]
                {
                    new[]
                    {
                        new[] {0, 2, 0},
                        new[] {7, 4, 3},
                        new[] {2, 2, 1},
                        new[] {1, 0, 1},
                        new[] {5, 4, 1},
                        new[] {6, 3, 2},
                        new[] {8, 3, 1},
                        new[] {3, 0, 4}
                    },
                    5, 6
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void The_Earliest_Moment_When_Everyone_Become_Friends_Tests(int[][] logs, int n, int expected)
    {
        var result = TheEarliestTimeThatEveryoneBecomeFriends.EarliestAcq(logs, n);
        result.Should().Be(expected);
    }
}