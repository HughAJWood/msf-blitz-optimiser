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

Example roster based on above tag manipulation:

```text
Char count: 194
Team(5) InfinityWatch - 882k - Adam Warlock, Phyla-Vell, Gamora, Moondragon, Nebula
Team(5) WebWarrior - 789k - Scarlet Spider, Spider-Man (Miles), Spider-Man, Spider-Punk, Ghost-Spider
Team(5) Kree - 743k - Ultimus, Captain Marvel, Ronan the Accuser, Minn-Erva, Korath the Pursuer
Team(5) Global - 741k - Captain America (Sam), Sharon Carter, Emma Frost, Stryfe, Mister Sinister
Team(5) Cosmic - 725k - Deathpool, Silver Surfer, Kestrel, Doctor Strange (Heartless), Kree Oracle
Team(5) DarkHunter - 693k - Ghost Rider, Scarlet Witch, Elsa Bloodstone, Morbius, Doctor Voodoo
Team(5) Astonishing - 653k - Iceman, Beast, Bishop, Kitty Pryde, Jubilee
Team(5) Inhuman - 639k - Black Bolt, Yo-Yo, Karnak, Crystal, Quake
Team(5) HeroesForHire - 627k - Shang-Chi, Misty Knight, Iron Fist, Colleen Wing, Luke Cage
Team(5) Symbiote - 611k - Anti-Venom, Spider-Man (Symbiote), Carnage, Scream, Venom
Team(5) WeaponX - 572k - Lady Deathstrike, Omega Red, Silver Samurai, Wolverine, Sabretooth
Team(5) City - 554k - Dagger, Cloak, Jessica Jones, Punisher, Swarm
Team(5) Uncanny - 505k - Phoenix, Colossus, Magik, Cyclops, Storm
Team(5) Shadowland - 503k - Night Nurse, Daredevil, White Tiger, Moon Knight, Elektra
Team(5) Asgard - 502k - Hela, Heimdall, Loki, Thor, Sif
Team(5) Bio - 496k - Sersi, Ikaris, A.I.M. Infector, Green Goblin, Kree Royal Guard
Team(5) Shield - 487k - Maria Hill, Nick Fury, Agent Coulson, Captain America, Black Widow
Team(5) XFactor - 471k - Shatterstar, Polaris, Longshot, Multiple Man, Namor
Team(5) Aim - 453k - A.I.M. Security, A.I.M. Researcher, Graviton, Scientist Supreme, A.I.M. Monstrosity
Team(5) Ravager - 450k - Ravager Stitcher, Star-Lord (T'Challa), Yondu, Ravager Boomer, Ravager Bruiser
Team(5) YoungAvenger - 447k - America Chavez, Squirrel Girl, Ms. Marvel, Echo, Kate Bishop
Team(5) Avenger - 438k - Vision, Doctor Doom, Hawkeye, Toad, Doctor Strange
Team(5) SinisterSix - 434k - Doctor Octopus, Rhino, Shocker, Mysterio, Electro
Team(5) BlackOrder - 410k - Ebony Maw, Thanos, Corvus Glaive, Proxima Midnight, Cull Obsidian
Team(5) PowerArmor - 396k - Ironheart, Rescue, War Machine, Iron Man, Falcon
Team(5) Xforce - 393k - Negasonic, Deadpool, Domino, Cable, X-23
Team(5) Hydra - 390k - Baron Zemo, Winter Soldier, Red Skull, Hydra Sniper, Hydra Scientist
Team(5) PymTech - 388k - Ghost, Yellowjacket, Stature, Ant-Man, Wasp
Team(5) FantasticFour - 384k - Invisible Woman, Human Torch, The Thing, Mister Fantastic, She-Hulk
Team(5) Brotherhood - 381k - Pyro, Blob, Magneto, Juggernaut, Mystique
Team(5) GotG - 372k - Rocket Raccoon, Star-Lord, Groot, Mantis, Drax
Team(5) Skill - 339k - S.H.I.E.L.D. Medic, S.H.I.E.L.D. Assault, S.H.I.E.L.D. Security, Yelena Belova, Mercenary Soldier
Team(5) Wakanda - 301k - Killmonger, Shuri, M'Baku, Black Panther, Okoye
Team(5) Tech - 288k - Ultron, Vulture, Hydra Grenadier, Crossbones, Hydra Rifle Trooper
Team(5) Brawler - 272k - Psylocke, Kree Reaper, Mordo, Taskmaster, S.H.I.E.L.D. Operative
Team(5) Hand - 251k - Nobu, Hand Assassin, Hand Sorceress, Hand Blademaster, Hand Sentry
Team(5) Controller - 238k - Kree Noble, Mercenary Riot Guard, Kingpin, Mercenary Lieutenant, Hydra Armored Guard
Team(5) Blaster - 218k - Bullseye, S.H.I.E.L.D. Trooper, A.I.M. Assaulter, Kree Cyborg, Mercenary Sniper
Team(4) Wave1Avenger - 116k - Hulk, Wong, Red Guardian, Hand Archer
39 Teams generated
```
