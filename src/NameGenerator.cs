namespace RepoNameGenerator;

public static class NameGenerator
{
    // ~10% chance of using the three-word "adjective-octo-noun" format,
    // mirroring GitHub's occasional use of their Octocat mascot in the middle.
    private const double OctoChance = 0.1;

    /// <summary>Generates <paramref name="count"/> unique random repo names.</summary>
    /// <param name="rng">Optional seeded RNG; uses <see cref="Random.Shared"/> when null.</param>
    public static IEnumerable<string> Generate(int count, Random? rng = null)
    {
        rng ??= Random.Shared;
        var usedAdjectives = new HashSet<string>(count);
        var usedNouns = new HashSet<string>(count);

        for (int i = 0; i < count; i++)
        {
            string adjective = PickUnused(WordLists.Adjectives, usedAdjectives, rng);
            string noun = PickUnused(WordLists.Nouns, usedNouns, rng);

            bool useOcto = rng.NextDouble() < OctoChance;
            yield return useOcto
                ? $"{adjective}-{WordLists.OctoInfix}-{noun}"
                : $"{adjective}-{noun}";
        }
    }

    internal static string PickUnused(string[] pool, HashSet<string> used, Random rng)
    {
        // Guard against requesting more unique items than the pool contains.
        if (used.Count >= pool.Length)
            used.Clear();

        string word;
        do { word = pool[rng.Next(pool.Length)]; }
        while (!used.Add(word));

        return word;
    }
}
