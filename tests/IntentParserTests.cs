using RepoNameGenerator;

namespace RepoNameGenerator.Tests;

public class IntentParserTests
{
    [Fact]
    public void ExtractKeywords_ReturnsEmptyForEmptyString()
    {
        Assert.Empty(IntentParser.ExtractKeywords(""));
    }

    [Fact]
    public void ExtractKeywords_ReturnsEmptyForWhitespace()
    {
        Assert.Empty(IntentParser.ExtractKeywords("   "));
    }

    [Fact]
    public void ExtractKeywords_ReturnsLowercase()
    {
        var keywords = IntentParser.ExtractKeywords("REST API Service");
        Assert.All(keywords, k => Assert.Equal(k.ToLowerInvariant(), k));
    }

    [Fact]
    public void ExtractKeywords_RemovesStopWords()
    {
        var keywords = IntentParser.ExtractKeywords("a web app for the team");
        Assert.DoesNotContain("a", keywords);
        Assert.DoesNotContain("for", keywords);
        Assert.DoesNotContain("the", keywords);
    }

    [Fact]
    public void ExtractKeywords_FiltersWordsShorterThanThreeChars()
    {
        // "go" = 2 chars, "an" = 2 chars — both filtered
        var keywords = IntentParser.ExtractKeywords("an go app");
        Assert.DoesNotContain("an", keywords);
        Assert.DoesNotContain("go", keywords);
    }

    [Fact]
    public void ExtractKeywords_ExtractsMeaningfulWords()
    {
        var keywords = IntentParser.ExtractKeywords("soap web app for upgrade testing");
        Assert.Contains("soap", keywords);
        Assert.Contains("web", keywords);
        Assert.Contains("upgrade", keywords);
        Assert.Contains("testing", keywords);
    }

    [Fact]
    public void ExtractKeywords_NoDuplicates()
    {
        var keywords = IntentParser.ExtractKeywords("test test testing");
        Assert.Equal(keywords.Count, keywords.Distinct().Count());
    }

    [Fact]
    public void ExtractKeywords_StripsPunctuation()
    {
        var keywords = IntentParser.ExtractKeywords("REST-API, web-service: upgrade/testing!");
        Assert.Contains("rest", keywords);
        Assert.Contains("api", keywords);
        Assert.Contains("web", keywords);
        Assert.Contains("service", keywords);
    }
}
