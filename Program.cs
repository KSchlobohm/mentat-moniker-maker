using RepoNameGenerator;

const int defaultCount = 10;

int count = ParseCount(args, defaultCount);

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("  GitHub-style repository name suggestions:");
Console.ResetColor();
Console.WriteLine();

int index = 1;
foreach (string name in NameGenerator.Generate(count))
{
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write($"  {index++,2}. ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(name);
    Console.ResetColor();
}

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("  Run again for more  |  dotnet run -- --count <N> for a custom list size");
Console.ResetColor();
Console.WriteLine();

static int ParseCount(string[] args, int fallback)
{
    for (int i = 0; i < args.Length - 1; i++)
    {
        if ((args[i] == "--count" || args[i] == "-n") &&
            int.TryParse(args[i + 1], out int n) && n > 0)
            return n;
    }
    return fallback;
}
