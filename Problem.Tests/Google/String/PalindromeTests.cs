using FluentAssertions;
using Problems.Google.String;

namespace Problem.Tests.Google.String;

public class PalindromeTests
{
    [Theory]
    [InlineData("anna")]
    [InlineData("an na")]
    [InlineData("ann a")]
    [InlineData("a nna")]
    [InlineData("Anana")]
    [InlineData("ANana")]
    [InlineData("anAna")]
    [InlineData("an              Ana")]
    public void PalindromeShouldReturnTrue(string word)
    {
        var palindromeResult = Palindrome.IsPalindrome(word);
        palindromeResult.Should().BeTrue();
    }

    [Theory]
    [InlineData("annan")]
    [InlineData("an nan")]
    [InlineData("ann an")]
    [InlineData("a nnan")]
    [InlineData("AnanaN")]
    [InlineData("ANanaN")]
    [InlineData("anAna N")]
    [InlineData("an     n         Ana")]
    public void PalindromeShouldReturnFalse(string word)
    {
        var palindromeResult = Palindrome.IsPalindrome(word);
        palindromeResult.Should().BeFalse();
    }
}