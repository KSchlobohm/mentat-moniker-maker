using System.Text.RegularExpressions;

namespace RepoNameGenerator;

public static class IntentParser
{
    private static readonly HashSet<string> StopWords = new(StringComparer.OrdinalIgnoreCase)
    {
        "a", "an", "the", "and", "or", "but", "for", "of", "to", "is", "are",
        "be", "been", "being", "that", "this", "it", "in", "on", "at", "with",
        "by", "from", "up", "about", "into", "through", "i", "me", "my", "we",
        "you", "he", "she", "they", "which", "who", "used", "use", "using",
        "build", "building", "make", "making", "create", "creating", "new",
        "simple", "some", "just", "very", "really", "so", "too", "also",
        "can", "will", "would", "could", "should", "may", "might", "need",
        "want", "like", "get", "give", "help", "lets", "let"
    };

    /// <summary>
    /// Extracts meaningful slug-safe keywords from a free-text intent statement.
    /// Removes stopwords, punctuation, and words shorter than 3 characters.
    /// </summary>
    public static IReadOnlyList<string> ExtractKeywords(string intent)
    {
        if (string.IsNullOrWhiteSpace(intent))
            return [];

        return [.. Regex.Split(intent.ToLowerInvariant(), @"[^a-z]+")
            .Where(w => w.Length >= 3 && !StopWords.Contains(w))
            .Distinct()];
    }
}
