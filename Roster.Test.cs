using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace MsfBlitzOptimiser;

[TestFixture]
public class RosterTests
{

    [Test]
    public void CanLoadRosterJSON()
    {
        var filename = $"{Directory.GetCurrentDirectory()}\\RosterExport.json";
        Assert.IsTrue(File.Exists(filename));
        var roster = new Roster();
        roster.ParseRoster(filename);
        var characters = roster.RosterList;
        foreach (var key in characters.Keys)
        {
            Assert.IsTrue(characters[key] != null, $"Failed on {key}");
        }
    }
    [Test]
    public void GetTags()
    {
        var roster = new Roster();
        Assert.IsTrue(roster?.AllChars?.data.Count() > 1);
    }
}