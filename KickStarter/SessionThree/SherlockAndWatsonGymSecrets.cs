namespace KickStarter.SessionThree;

/// <summary>
///     It is a dp problem with some math
/// </summary>
public class SherlockAndWatsonGymSecrets
{
    private const int MODULO = 1_000_000_007;

    public int CountPairs(int sherlock, int watson, int n, int k)
    {
        return -1;
    }
}

public class SherlockAndWatsonGymSecretsTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    1, 1, 5, 3,
                    8
                },
                new object[]
                {
                    1, 1, 4, 5,
                    3
                },
                new object[]
                {
                    1, 1, 2, 2,
                    0
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Sherlock_and_watson_gym_secrets_tests(int sherlock, int watson, int n, int k, int expected)
    {
        //var result = new SherlockAndWatsonGymSecrets().CountPairs(sherlock, watson, n, k);
        //result.Should().Be(expected);
    }
}