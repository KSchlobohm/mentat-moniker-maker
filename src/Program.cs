using RepoNameGenerator;

var cli = CliArgs.Parse(args);
IReadOnlyList<string>? keywords = cli.Intent is not null
    ? IntentParser.ExtractKeywords(cli.Intent)
    : null;

Console.WriteLine();

// ── Random suggestions ──────────────────────────────────────────────────────
PrintHeader("Random suggestions");

int index = 1;
foreach (string name in NameGenerator.Generate(cli.Count))
    PrintName(ref index, name);

// ── Intent-aligned suggestions (only when --intent is provided) ─────────────
if (keywords is not null)
{
    Console.WriteLine();

    if (keywords.Count > 0)
    {
        PrintHeader($"Aligned with: \"{cli.Intent}\"");
        foreach (string name in IntentNameGenerator.Generate(keywords, cli.Count))
            PrintName(ref index, name);
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("  No usable keywords found in intent — showing random names only.");
        Console.ResetColor();
    }
}

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("  Run again for more  |  --count <N>  |  --intent \"describe your project\"");
Console.ResetColor();
Console.WriteLine();

// ── Helpers ─────────────────────────────────────────────────────────────────
static void PrintHeader(string text)
{
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine($"  {text}:");
    Console.ResetColor();
    Console.WriteLine();
}

static void PrintName(ref int index, string name)
{
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write($"  {index++,2}. ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(name);
    Console.ResetColor();
}
