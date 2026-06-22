using RepoNameGenerator;

const int defaultCount = 6;

(int count, string? intent) = ParseArgs(args, defaultCount);
IReadOnlyList<string>? keywords = intent is not null
    ? IntentParser.ExtractKeywords(intent)
    : null;

Console.WriteLine();

// ── Random suggestions ──────────────────────────────────────────────────────
PrintHeader("Random suggestions");

int index = 1;
foreach (string name in NameGenerator.Generate(count))
    PrintName(ref index, name);

// ── Intent-aligned suggestions (only when --intent is provided) ─────────────
if (keywords is not null)
{
    Console.WriteLine();

    if (keywords.Count > 0)
    {
        PrintHeader($"Aligned with: \"{intent}\"");
        foreach (string name in IntentNameGenerator.Generate(keywords, count))
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

static (int count, string? intent) ParseArgs(string[] args, int fallback)
{
    int count = fallback;
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

    return (count, intent);
}
