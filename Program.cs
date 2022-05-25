using MsfBlitzOptimiser;

var filename = $"{Directory.GetCurrentDirectory()}\\RosterExport_may_2022.json";
var roster = new Roster();
roster.ParseRoster(filename);

// AddCustomTag("RedSkull");
// RemoveCharTags(roster, "Red Skull");
// RemoveCharTags(roster, "Hydra Rifle Trooper");
// RemoveCharTags(roster, "Hydra Armored Guard");
// RemoveCharTags(roster, "Hydra Scientist");
// RemoveCharTags(roster, "Hydra Sniper");
// AddTagToChar(roster, "Red Skull", "RedSkull");
// AddTagToChar(roster, "Hydra Rifle Trooper", "RedSkull");
// AddTagToChar(roster, "Hydra Armored Guard", "RedSkull");
// AddTagToChar(roster, "Hydra Scientist", "RedSkull");
// AddTagToChar(roster, "Hydra Sniper", "RedSkull");

RemoveCharTags(roster, "Sersi");
RemoveCharTags(roster, "Ikaris");
AddTagToChar(roster, "Sersi", "Bio");
AddTagToChar(roster, "Ikaris", "Bio");
AddTagToChar(roster, "Thanos", "BlackOrder");
AddTagToChar(roster, "Namor", "XFactor");
AddTagToChar(roster, "She-Hulk", "FantasticFour");
//AddTagToChar(roster, "Scarlet Witch", "DarkHunter");

var charCount = roster
    .AllChars
    .data
    .Count(c => c.power > 0);

Console.WriteLine($"Char count: {charCount}");

var tags = roster.AllChars.data
    .Where(c => c.traits != null)
    .SelectMany(c => c.traits)
    .Select(c => c.id)
    .Distinct()
    .OrderBy(c => c)
    .ToList();

Dictionary<string, List<Character>> blitzList = SeedBlitzList(tags);
AddCharactersToBlitzLIst(roster, blitzList);
RemoveEmptyTeams(blitzList);
OptimiseTeams(blitzList);
RemoveEmptyTeams(blitzList);
OutputTeams(blitzList);

static Dictionary<string, List<Character>> SeedBlitzList(List<string> tags)
{
    // Seed the blitzList with the tags
    var blitzList = new Dictionary<string, List<Character>>();
    foreach (var tag in tags)
    {
        blitzList.Add(tag, new List<Character>());
    }

    return blitzList;
}

static void AddCharactersToBlitzLIst(Roster roster, Dictionary<string, List<Character>> blitzList)
{
    // Only character with a power level of over 0
    var added = new List<string>();
    foreach (var tag in CharTags.PriorityOrder)
    {
        var charactersWithTrait = roster.AllChars.data
        .Where(c => c.traits != null)
        .Where(c => c.traits.Any(t => t.id == tag) && c.power > 0)
        .OrderByDescending(c => c.power)
        .ToList();

        do
        {
            if (!blitzList.ContainsKey(tag)) break;
            if (blitzList[tag].Count() > 4) break;
            var nextAvailableCharacter = charactersWithTrait.FirstOrDefault(ct => !added.Exists(c => c == ct.name));
            if (nextAvailableCharacter == null) break;

            blitzList[tag].Add(nextAvailableCharacter);
            added.Add(nextAvailableCharacter.name);
        } while (true);
    }
}

static void RemoveEmptyTeams(Dictionary<string, List<Character>> blitzList)
{
    // Remove empty teams
    var toRemove = blitzList.Where(b => !b.Value.Any()).Select(b => b.Key).ToList();
    foreach (var removeKey in toRemove)
    {
        blitzList.Remove(removeKey);
    }
}

static void OptimiseTeams(Dictionary<string, List<Character>> blitzList)
{
    // Optimise team list
    var toRemove = new List<string>();
    foreach (var team in blitzList)
    {
        if (team.Value.Count < 5)
        {
            var suitableMembers = blitzList
                .OrderByDescending(b => b.Value.Count())
                .Where(b => b.Value.Count < 5)
                .SelectMany(b => b.Value)
                .OrderByDescending(c => c.power)
                .ToList();

            foreach (var suitableMember in suitableMembers)
            {
                blitzList.Where(b => b.Value.Contains(suitableMember))
                    .FirstOrDefault()
                    .Value
                    .Remove(suitableMember);

                team.Value.Add(suitableMember);
                if (team.Value.Count == 5) break;
            }
        }
    }
}

static void OutputTeams(Dictionary<string, List<Character>> blitzList)
{
    var blitzListDescendingByPower = blitzList
        .OrderByDescending(t => t.Value.Sum(c => c.power));

    foreach (var team in blitzListDescendingByPower)
    {
        var teamList = team.Value;
        var teamListFormatted = String
            .Join(", ", teamList.Select(c => c.name)
            .ToArray());

        var totalPower = (int)(teamList.Sum(c => c.power) / 1000);

        Console.WriteLine($"Team({teamList.Count()}) {team.Key} - {totalPower}k - {teamListFormatted}");
    }
    var teamCount = blitzList
        .Count(c => c.Value.Any());

    Console.WriteLine($"{teamCount} Teams generated");
}

static void AddTagToChar(Roster roster, string name, string tag)
{
    roster.AllChars.data
        .First(c => c.name == name)
        .traits
        .Add(new Trait { id = tag, name = tag.ToUpper() });
    var t = roster.AllChars.data
        .First(c => c.name == name);
}

static void RemoveCharTags(Roster roster, string name)
{
    roster.AllChars.data
        .First(c => c.name == name)
        .traits
        .Clear();
}

static void AddCustomTag(string tag)
{
    CharTags.PriorityOrder.Add(tag);
}