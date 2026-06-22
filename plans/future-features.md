# Future Feature: Smarter Intent-to-Name Alignment

## Problem

The current `--intent` flag uses simple keyword extraction (tokenize, remove stopwords).
This produces names like `solid-soap` or `testing-vortex` which are directionally correct
but not semantically rich. A user who types:

> "a SOAP web service used for upgrade testing"

would ideally get names that evoke **reliability, integration, migration, compatibility**
— not just the raw tokens `soap`, `upgrade`, `testing`.

---

## Proposed Approaches (in order of complexity)

### 1. Synonym / Theme Expansion (No External Dependencies)
Maintain a hand-curated `ThemeMap` dictionary that maps common domain keywords to
clusters of related adjectives and nouns already in the word lists.

```csharp
// Example entries
{ "test",    adjectives: ["reliable","validated","solid"], nouns: ["scaffold","blueprint","prism"] },
{ "web",     adjectives: ["digital","responsive","connected"], nouns: ["portal","gateway","beacon"] },
{ "upgrade", adjectives: ["improved","enhanced","refactored"], nouns: ["catalyst","engine","turbine"] },
{ "api",     adjectives: ["precise","elegant","nimble"], nouns: ["gateway","compass","circuit"] },
```

This gives semantically richer output without network calls or ML models.

### 2. Word Embedding Similarity (Local ML)
Use `Microsoft.ML` with a pre-trained word embedding model (e.g., GloVe or FastText)
to find words in `WordLists` that are most similar to the intent keywords by cosine
distance. Adds ~50MB model weight but works fully offline.

### 3. LLM-Powered Generation (Optional Online Mode)
Add an optional `--ai` flag that calls a configurable LLM endpoint (Azure OpenAI,
Ollama, or any OpenAI-compatible API) to generate names with deep semantic awareness.

```bash
dotnet run -- --intent "upgrade testing framework" --ai
# Calls configured endpoint, returns semantically aligned names
# Gracefully falls back to local generation if endpoint unavailable
```

Configuration via environment variable or `appsettings.json`:
```json
{ "AiEndpoint": "http://localhost:11434/v1", "AiModel": "llama3.2" }
```

### 4. Interactive Refinement Mode
Add a `--interactive` flag that shows names one at a time and accepts feedback
(like / dislike / regenerate) to steer the generator toward preferred vocabulary.

---

## Acceptance Criteria for Theme Expansion (Approach 1)

- [ ] `ThemeMap` covers at least 30 common software domain keywords
- [ ] Intent-aligned names use theme-expanded words at least 50% of the time
- [ ] All existing tests still pass
- [ ] New tests cover theme expansion round-trips
- [ ] No external dependencies added
