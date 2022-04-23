using System.Collections.Generic;
using System.Diagnostics.Tracing;
using FluentAssertions;
using Problems.Google;
using Xunit;

namespace Problem.Tests.Google;

public class UniqueEmailAddressTests
{
    [Theory]
    [InlineData(new string[] {"test.email+alex@leetcode.com","test.e.mail+bob.cathy@leetcode.com","testemail+david@lee.tcode.com"}, 2)]
    [InlineData(new string[] {"a@leetcode.com","b@leetcode.com","c@leetcode.com"}, 3)]
    public void Unique_Email_Address_Tests(string[] emails, int expectedMails)
    {
        var result = UniqueEmailAddress.NumUniqueEmails(emails);
        result.Should().Be(expectedMails);
    }
}