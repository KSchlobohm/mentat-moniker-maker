namespace RepoNameGenerator;

public static class IntentNameGenerator
{
    /// <summary>
    /// Generates <paramref name="count"/> names steered by the given <paramref name="keywords"/>.
    /// Three strategies are cycled to produce variety:
    ///   0 → {adjective}-{keyword}      e.g. "reliable-upgrade"
    ///   1 → {keyword}-{noun}           e.g. "testing-vortex"
    ///   2 → {adjective}-{keyword}-{noun}  e.g. "solid-soap-engine"
    /// Falls back to random generation when no keywords are supplied.
    /// </summary>
    /// <param name="rng">Optional seeded RNG; uses <see cref="Random.Shared"/> when null.</param>
    public static IEnumerable<string> Generate(
        IReadOnlyList<string> keywords,
        int count,
        Random? rng = null)
    {
        rng ??= Random.Shared;

        if (keywords.Count == 0)
        {
            foreach (string name in NameGenerator.Generate(count, rng))
                yield return name;
            yield break;
        }

        var usedAdjectives = new HashSet<string>(count);
        var usedNouns = new HashSet<string>(count);

        for (int i = 0; i < count; i++)
        {
            string keyword = keywords[i % keywords.Count];
            string adj  = NameGenerator.PickUnused(WordLists.Adjectives, usedAdjectives, rng);
            string noun = NameGenerator.PickUnused(WordLists.Nouns, usedNouns, rng);

            yield return (i % 3) switch
            {
                0 => $"{adj}-{keyword}",
                1 => $"{keyword}-{noun}",
                _ => $"{adj}-{keyword}-{noun}"
            };
        }
    }
}
