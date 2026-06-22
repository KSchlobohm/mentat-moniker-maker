using RepoNameGenerator;

namespace RepoNameGenerator.Tests;

public class IntentNameGeneratorTests
{
    [Fact]
    public void Generate_ReturnsExactCount()
    {
        var keywords = IntentParser.ExtractKeywords("soap web service");
        var names = IntentNameGenerator.Generate(keywords, 6).ToList();
        Assert.Equal(6, names.Count);
    }

    [Fact]
    public void Generate_AllNamesContainHyphen()
    {
        var keywords = IntentParser.ExtractKeywords("web testing tool");
        var names = IntentNameGenerator.Generate(keywords, 6).ToList();
        Assert.All(names, n => Assert.Contains('-', n));
    }

    [Fact]
    public void Generate_AllNamesAreLowercase()
    {
        var keywords = IntentParser.ExtractKeywords("REST API Service");
        var names = IntentNameGenerator.Generate(keywords, 6).ToList();
        Assert.All(names, n => Assert.Equal(n.ToLowerInvariant(), n));
    }

    [Fact]
    public void Generate_WithKeywords_SomeNamesIncludeKeyword()
    {
        // Use a distinctive keyword unlikely to appear in random word lists
        var keywords = IntentParser.ExtractKeywords("zymurgy fermentation");
        var names = IntentNameGenerator.Generate(keywords, 6).ToList();
        Assert.Contains(names, n => n.Contains("zymurgy") || n.Contains("fermentation"));
    }

    [Fact]
    public void Generate_WithEmptyKeywords_FallsBackToRandomNames()
    {
        var names = IntentNameGenerator.Generate([], 6).ToList();
        Assert.Equal(6, names.Count);
        Assert.All(names, n => Assert.Contains('-', n));
    }

    [Fact]
    public void Generate_WithSameSeed_ProducesSameSequence()
    {
        var keywords = IntentParser.ExtractKeywords("upgrade testing service");
        var names1 = IntentNameGenerator.Generate(keywords, 6, new Random(99)).ToList();
        var names2 = IntentNameGenerator.Generate(keywords, 6, new Random(99)).ToList();
        Assert.Equal(names1, names2);
    }
}
