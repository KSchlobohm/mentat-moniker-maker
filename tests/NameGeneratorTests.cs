using RepoNameGenerator;

namespace RepoNameGenerator.Tests;

public class NameGeneratorTests
{
    [Fact]
    public void Generate_ReturnsExactCount()
    {
        var names = NameGenerator.Generate(5).ToList();
        Assert.Equal(5, names.Count);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(6)]
    [InlineData(20)]
    public void Generate_ReturnsRequestedCount(int count)
    {
        Assert.Equal(count, NameGenerator.Generate(count).Count());
    }

    [Fact]
    public void Generate_AllNamesAreLowercase()
    {
        var names = NameGenerator.Generate(15).ToList();
        Assert.All(names, n => Assert.Equal(n.ToLowerInvariant(), n));
    }

    [Fact]
    public void Generate_AllNamesContainHyphen()
    {
        var names = NameGenerator.Generate(15).ToList();
        Assert.All(names, n => Assert.Contains('-', n));
    }

    [Fact]
    public void Generate_NoDuplicatesInBatch()
    {
        var names = NameGenerator.Generate(30).ToList();
        Assert.Equal(names.Count, names.Distinct().Count());
    }

    [Fact]
    public void Generate_WithSameSeed_ProducesSameSequence()
    {
        var names1 = NameGenerator.Generate(6, new Random(42)).ToList();
        var names2 = NameGenerator.Generate(6, new Random(42)).ToList();
        Assert.Equal(names1, names2);
    }

    [Fact]
    public void Generate_WithDifferentSeeds_ProducesDifferentSequences()
    {
        var names1 = NameGenerator.Generate(6, new Random(1)).ToList();
        var names2 = NameGenerator.Generate(6, new Random(2)).ToList();
        Assert.NotEqual(names1, names2);
    }

    [Fact]
    public void Generate_NamesOnlyContainLowercaseLettersAndHyphens()
    {
        var names = NameGenerator.Generate(20).ToList();
        Assert.All(names, n => Assert.Matches(@"^[a-z]+(-[a-z]+)+$", n));
    }
}
