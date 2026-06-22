namespace RepoNameGenerator;

/// <summary>Parsed command-line arguments.</summary>
public sealed record CliArgs(int Count, string? Intent)
{
    public const int DefaultCount = 6;

    /// <summary>Parses <paramref name="args"/> into a <see cref="CliArgs"/> instance.</summary>
    public static CliArgs Parse(string[] args, int defaultCount = DefaultCount)
    {
        int count = defaultCount;
        string? intent = null;

        for (int i = 0; i < args.Length; i++)
        {
            if ((args[i] is "--count" or "-n") && i + 1 < args.Length
                && int.TryParse(args[i + 1], out int n) && n > 0)
            {
                count = n;
                i++;
            }
            else if ((args[i] is "--intent" or "-i") && i + 1 < args.Length)
            {
                intent = args[i + 1];
                i++;
            }
        }

        return new CliArgs(count, intent);
    }
}
