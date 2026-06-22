namespace RepoNameGenerator;

public static class WordLists
{
    // Adjectives modeled on GitHub's observed vocabulary:
    // whimsical, action-y, and descriptive — no nature themes.
    public static readonly string[] Adjectives =
    [
        "adorable", "adventurous", "affectionate", "agile", "amazing",
        "animated", "astral", "audacious", "automatic", "awesome",
        "balanced", "blazing", "bold", "bookish", "bountiful",
        "brave", "bright", "brilliant", "bubbly", "careful",
        "cautious", "charming", "cheerful", "clean", "clever",
        "comfortable", "compact", "confident", "cool", "crispy",
        "cuddly", "curious", "curly", "cute", "daring",
        "dazzling", "dedicated", "delightful", "devoted", "digital",
        "dynamic", "eager", "educated", "electric", "elegant",
        "enchanted", "energetic", "enhanced", "epic", "excellent",
        "excited", "exotic", "expert", "fancy", "fantastic",
        "fast", "fearless", "festive", "fictional", "fierce",
        "fluffy", "focused", "friendly", "fun", "funny",
        "fuzzy", "gallant", "gentle", "gifted", "glorious",
        "golden", "graceful", "gracious", "grand", "great",
        "groovy", "happy", "hardy", "harmonious", "helpful",
        "historic", "humble", "improved", "incredible", "industrial",
        "informed", "inspiring", "intelligent", "inventive", "jovial",
        "joyful", "keen", "kind", "laughing", "lavish",
        "legendary", "lively", "logical", "loving", "loyal",
        "lucky", "magical", "majestic", "melodic", "memorable",
        "mighty", "modern", "musical", "mysterious", "natural",
        "neat", "nimble", "noble", "optimal", "organized",
        "peaceful", "perfect", "playful", "polished", "popular",
        "powerful", "precise", "productive", "proud", "psychic",
        "quirky", "radiant", "rapid", "redesigned", "refactored",
        "reliable", "remarkable", "responsive", "reworked", "robust",
        "scaling", "sharp", "shiny", "silver", "sleek",
        "smart", "smooth", "solid", "sophisticated", "special",
        "speedy", "splendid", "stellar", "studious", "super",
        "supreme", "surprising", "sweet", "symmetrical", "talented",
        "thoughtful", "tidy", "timeless", "tiny", "trendy",
        "trusty", "turbo", "ultimate", "unique", "universal",
        "urban", "vibrant", "vigilant", "vivid", "warm",
        "wild", "witty", "wonderful", "zealous", "zesty"
    ];

    // Nouns modeled on GitHub's observed vocabulary:
    // concrete, quirky, and memorable objects — often whimsical.
    public static readonly string[] Nouns =
    [
        "adventure", "algorithm", "anvil", "artifact", "barnacle",
        "bassoon", "beacon", "biscuit", "blizzard", "blueprint",
        "broccoli", "burrito", "calculator", "camera", "canoe",
        "carnival", "carrot", "castle", "catalog", "chainsaw",
        "chimera", "cinnamon", "circuit", "coconut", "comet",
        "compass", "cookie", "cornucopia", "cosmos", "cucumber",
        "cupcake", "dagger", "doodle", "dollop", "dragon",
        "enigma", "engine", "eureka", "explorer", "factory",
        "fiesta", "fishbowl", "flame", "fork", "formula",
        "fountain", "gadget", "garbanzo", "gateway", "giggle",
        "glacier", "globe", "goblin", "guitar", "hammer",
        "harbor", "harmonica", "hat", "horizon", "hurricane",
        "igloo", "instrument", "invention", "island", "journal",
        "kaleidoscope", "keyboard", "lamp", "lantern", "laser",
        "lemon", "library", "lighthouse", "llama", "locket",
        "locomotive", "mango", "map", "marble", "meadow",
        "megaphone", "mochi", "module", "moonbeam", "mosaic",
        "muffin", "nebula", "noodle", "notebook", "nugget",
        "octocat", "orbit", "origami", "pancake", "paradox",
        "penguin", "phoenix", "pickle", "pillow", "pinecone",
        "pipeline", "pixel", "pizza", "planet", "platypus",
        "portal", "potato", "pretzel", "prism", "puzzle",
        "rainbow", "reactor", "robot", "rocket", "safari",
        "satellite", "saxophone", "scroll", "shield", "skillet",
        "spaceship", "spaghetti", "spectrum", "spoon", "sprocket",
        "stardust", "submarine", "sundae", "telescope", "telegram",
        "toaster", "tornado", "tortilla", "treasure", "trombone",
        "tundra", "turbine", "umbrella", "unicorn", "universe",
        "vortex", "waffle", "walrus", "widget", "wizard",
        "workshop", "wrench", "zeppelin", "zucchini"
    ];

    // GitHub occasionally inserts "octo" as a middle word as a nod to Octocat.
    // When the three-word format is used: adjective-octo-noun
    public static readonly string OctoInfix = "octo";
}
