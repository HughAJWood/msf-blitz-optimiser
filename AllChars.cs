namespace MsfBlitzOptimiser;
internal class Trait
{
    public string? id;
    public string? name;
}
internal class Character
{
    public int power = 0;
    public string? id;
    public bool mission;
    public string? name;
    public string? description;
    public string? portrait;

    public List<Trait>? starItems;
    public string? status;
    public int unlockStars;
    public List<Trait>? traits;
    public List<Trait>? invisibleTraits;
}
internal class AllChars
{
    public List<Character>? data;
    public dynamic meta;
}