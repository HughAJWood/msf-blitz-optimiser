# msf-blitz-optimiser
Takes GROOT export and optimises teams, AllChars is not updated automatically.

RosterExport comes from GROOT export in Mantis
AllChars is from the all char API call in MSG.gg

Customise tags at the top of Program.cs

```c#
// Force Sersi and Ikarus to be in the bio team
RemoveCharTags(roster, "Sersi");
RemoveCharTags(roster, "Ikaris");
AddTagToChar(roster, "Sersi", "Bio");
AddTagToChar(roster, "Ikaris", "Bio");

AddTagToChar(roster, "Thanos", "BlackOrder");
AddTagToChar(roster, "Namor", "XFactor");
AddTagToChar(roster, "She-Hulk", "FantasticFour");
AddTagToChar(roster, "Scarlet Witch", "DarkHunter");
```

Then characters are sorted Tag > Power

- This isn't a non coder friendly solution
