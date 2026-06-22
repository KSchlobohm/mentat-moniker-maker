# Repo Name Generator

A .NET 10 console app that generates GitHub-style `adjective-noun` repository names instantly — no browser, no refreshing.

## Quick Start

```bash
cd src
dotnet run
```

**Output:**

```
  Random suggestions:

   1. turbo-carnival
   2. psychic-garbanzo
   3. legendary-octo-spoon
   4. solid-blueprint
   5. fuzzy-rocket
   6. studious-doodle

  Run again for more  |  --count <N>  |  --intent "describe your project"
```

---

## Usage

### Random names (default)

```bash
dotnet run                   # 6 random names
dotnet run -- --count 10     # 10 random names
dotnet run -- -n 3           # 3 random names (short flag)
```

### Intent-aligned names

Provide a short description of your project and the generator will produce an additional
set of names that incorporate your keywords alongside the random suggestions.

```bash
dotnet run -- --intent "soap web app for upgrade testing"
dotnet run -- -i "REST API service"
dotnet run -- --intent "data pipeline for ETL" --count 4
```

**Output with `--intent "soap web app for upgrade testing"`:**

```
  Random suggestions:

   1. legendary-spoon
   2. animated-barnacle
   3. fearless-mosaic
   4. nimble-satellite
   5. vivid-compass
   6. studious-rocket

  Aligned with: "soap web app for upgrade testing":

   7. reliable-soap
   8. web-vortex
   9. solid-upgrade-engine
  10. improved-testing
  11. app-prism
  12. daring-web-blueprint

  Run again for more  |  --count <N>  |  --intent "describe your project"
```

---

## Flags

| Flag | Short | Description | Default |
|------|-------|-------------|---------|
| `--count` | `-n` | Names generated per section | `6` |
| `--intent` | `-i` | Statement of intent for aligned suggestions | *(none)* |

---

## Running Tests

```bash
# From repo root
dotnet test

# With detailed output
dotnet test --logger "console;verbosity=normal"
```

**Test coverage includes:**

- `NameGeneratorTests` — count, lowercase, hyphen format, no duplicates, seeded reproducibility
- `IntentParserTests` — stopword removal, short-word filtering, punctuation stripping, deduplication
- `IntentNameGeneratorTests` — keyword inclusion, fallback to random, seeded reproducibility

---

## Project Structure

```
mentat-moniker-maker/
├── src/
│   ├── RepoNameGenerator.csproj
│   ├── Program.cs              # CLI entry point
│   ├── NameGenerator.cs        # Random adjective-noun pairs
│   ├── IntentNameGenerator.cs  # Keyword-steered name generation
│   ├── IntentParser.cs         # Keyword extraction from free text
│   └── WordLists.cs            # ~160 adjectives, ~140 nouns
├── tests/
│   ├── RepoNameGenerator.Tests.csproj
│   ├── NameGeneratorTests.cs
│   ├── IntentParserTests.cs
│   └── IntentNameGeneratorTests.cs
├── plans/
│   └── future-features.md      # Roadmap: theme maps, ML, LLM mode
└── README.md
```

---

## How Names Are Generated

- **Format:** `adjective-noun` (2 words) or `adjective-octo-noun` (3 words, ~10% of the time — a nod to GitHub's Octocat mascot)
- **Separator:** always a hyphen `-`, never an underscore
- **Case:** always lowercase
- **Numbers:** never appended (unlike Heroku-style generators)
- **Word lists:** ~160 whimsical adjectives and ~140 quirky nouns modelled on GitHub's observed vocabulary

**Intent-aligned strategies** (cycled for variety):

| Strategy | Example (intent: "soap upgrade") |
|----------|----------------------------------|
| `adjective-keyword` | `reliable-soap` |
| `keyword-noun` | `upgrade-vortex` |
| `adjective-keyword-noun` | `solid-soap-engine` |
