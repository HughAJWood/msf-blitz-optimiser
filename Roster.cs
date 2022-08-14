using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MsfBlitzOptimiser;

internal class Roster
{
    private string _baseUrl = "https://api.marvelstrikeforce.com";

    internal Dictionary<string, dynamic>? RosterList { get; private set; }

    internal AllChars? AllChars { get; private set; }
    internal Roster()
    {
        ParseAllChars();
    }
    private void ParseAllChars()
    {
        var filename = $"{Directory.GetCurrentDirectory()}\\AllChars.json";
        var fileContents = File.ReadAllText(filename).Trim();
        AllChars = JsonConvert.DeserializeObject<AllChars>(fileContents, new ExpandoObjectConverter());
    }

    internal void ParseRoster(string filename)
    {
        if (!File.Exists(filename)) return;
        if (!filename.ToUpper().EndsWith("JSON")) return;

        // Load json and convert from object to array
        var fileContents = File.ReadAllText(filename).Trim();
        RosterList = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(fileContents, new ExpandoObjectConverter());

        foreach (var key in RosterList.Keys)
        {
            AllChars.data.First(c => c.id == key).power = RosterList[key].Power;
        }
    }
}