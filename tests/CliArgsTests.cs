using RepoNameGenerator;

namespace RepoNameGenerator.Tests;

public class CliArgsTests
{
    [Fact]
    public void Parse_ReturnsDefaultCount_WhenNoArgs()
    {
        var cli = CliArgs.Parse([]);
        Assert.Equal(CliArgs.DefaultCount, cli.Count);
    }

    [Fact]
    public void Parse_ReturnsNullIntent_WhenNotProvided()
    {
        var cli = CliArgs.Parse([]);
        Assert.Null(cli.Intent);
    }

    [Fact]
    public void Parse_ParsesLongCountFlag()
    {
        var cli = CliArgs.Parse(["--count", "10"]);
        Assert.Equal(10, cli.Count);
    }

    [Fact]
    public void Parse_ParsesShortCountFlag()
    {
        var cli = CliArgs.Parse(["-n", "3"]);
        Assert.Equal(3, cli.Count);
    }

    [Fact]
    public void Parse_ParsesLongIntentFlag()
    {
        var cli = CliArgs.Parse(["--intent", "soap web service"]);
        Assert.Equal("soap web service", cli.Intent);
    }

    [Fact]
    public void Parse_ParsesShortIntentFlag()
    {
        var cli = CliArgs.Parse(["-i", "REST API"]);
        Assert.Equal("REST API", cli.Intent);
    }

    [Fact]
    public void Parse_ParsesCountAndIntentTogether()
    {
        var cli = CliArgs.Parse(["--intent", "web app", "--count", "4"]);
        Assert.Equal("web app", cli.Intent);
        Assert.Equal(4, cli.Count);
    }

    [Fact]
    public void Parse_IgnoresZeroCount()
    {
        var cli = CliArgs.Parse(["--count", "0"]);
        Assert.Equal(CliArgs.DefaultCount, cli.Count);
    }

    [Fact]
    public void Parse_IgnoresNegativeCount()
    {
        var cli = CliArgs.Parse(["--count", "-5"]);
        Assert.Equal(CliArgs.DefaultCount, cli.Count);
    }

    [Fact]
    public void Parse_IgnoresNonNumericCount()
    {
        var cli = CliArgs.Parse(["--count", "abc"]);
        Assert.Equal(CliArgs.DefaultCount, cli.Count);
    }

    [Fact]
    public void Parse_IgnoresUnrecognizedFlags()
    {
        var cli = CliArgs.Parse(["--unknown", "value"]);
        Assert.Equal(CliArgs.DefaultCount, cli.Count);
        Assert.Null(cli.Intent);
    }

    [Fact]
    public void Parse_HandlesCountFlagAtEnd_WithNoValue()
    {
        // --count with no following value should not throw
        var cli = CliArgs.Parse(["--count"]);
        Assert.Equal(CliArgs.DefaultCount, cli.Count);
    }

    [Fact]
    public void Parse_HandlesIntentFlagAtEnd_WithNoValue()
    {
        // --intent with no following value should not throw
        var cli = CliArgs.Parse(["--intent"]);
        Assert.Null(cli.Intent);
    }
}
