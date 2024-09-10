namespace Domain.Entities;

public class CharacterEntity
{
    // PK
    public int Id { get; set; }
    
    // Common props
    public string Name { get; set; }
    public byte Race { get; set; }
    public byte Gender { get; set; }
    public byte Class { get; set; }
    public bool IsAlive { get; set; }
    
    // Level props
    public ushort Level { get; set; }
    public int CurrentExp { get; set; }
    public int LevelExp { get; set; }
    
    // Relation props
    public StatsEntity Stats { get; set; }
}