# Future Feature: Smarter Intent-to-Name Alignment

## Problem

The current `--intent` flag uses simple keyword extraction (tokenize, remove stopwords).
This produces names like `solid-soap` or `testing-vortex` which are directionally correct
but not semantically rich. A user who types:

> "a SOAP web service used for upgrade testing"

would ideally get names that evoke **reliability, integration, migration, compatibility**
— not just the raw tokens `soap`, `upgrade`, `testing`.

---

## Name Quality Dimensions

A good repo name can be evaluated on several independent axes. The generator currently
ignores all of them. Future work should let users dial these up or down.

### 1. Sound — Alliteration and Rhythm
Alliteration (`mentat-moniker-maker`) can make a name feel cohesive and memorable.
But it can also feel forced or silly. It works when the words are strong independently;
it backfires when you're clearly reaching for the pattern.

- ✅ Works: `mentat-moniker-maker` — each word earns its place
- ❌ Forced: `boring-bland-builder` — alliteration can't rescue weak words

A future `--alliterate` flag could offer alliterative suggestions on demand rather than
as a default, letting the user decide when the technique fits.

### 2. Resonance — Cultural / Sci-Fi / Mythological References
A reference to shared cultural material (`mentat`, `kobayashi`, `moirai`) creates
instant recognition and personality for audiences who get it. But it only works when:
- The reference audience overlaps with the actual audience (e.g. Dune ref for developers ✅)
- The reference meaning aligns with the project's purpose
- It doesn't feel obscure or alienating to those outside the reference

A future `--theme <sci-fi|mythology|literature|neutral>` flag could steer the noun
pool toward themed word lists for audiences who want the nod — and away for those who don't.

### 3. Clarity — Does It Hint at Purpose?
Some names are pure whimsy (`turbo-carnival`); others directionally signal what something
does (`mentat-moniker-maker`). Neither is wrong — it depends on whether the project
*wants* to be self-describing or prefers brand-style abstraction.

A future `--style <descriptive|abstract|balanced>` flag could control this tradeoff.

---

## Proposed Implementation Approaches (in order of complexity)

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
