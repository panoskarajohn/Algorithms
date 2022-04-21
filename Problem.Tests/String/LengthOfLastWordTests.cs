using FluentAssertions;
using Problems.String;
using Xunit;

namespace Problem.Tests.String;

public class LengthOfLastWordTests
{
    [Theory]
    [InlineData("Hello World", 5)]
    [InlineData("   fly me   to   the moon  ", 4)]
    [InlineData("luffy is still joyboy", 6)]
    public void Length_Of_Last_Word_Tests(string sentence, int expectedLastWordLength)
    {
        var result = LengthOfLastWord.Execute(sentence);
        result.Should().Be(expectedLastWordLength);
    }
}