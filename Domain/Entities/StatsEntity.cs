namespace Domain.Entities;

public class StatsEntity
{
    // PK - FK
    public int CharacterId { get; set; }
    
    // Stats props
    public ushort Strength { get; set; }
    public ushort Speed { get; set; }
    public ushort Intelligence { get; set; }
    
    // Hp | Energy props
    public ushort MaxHp { get; set; }
    public ushort CurrentHp { get; set; }
    public ushort MaxEnergy { get; set; }
    public ushort CurrentEnergy { get; set; }
}