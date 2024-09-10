namespace Domain.Entities;

public class ActionEntity
{
    // PK
    public int Id { get; set; }
    
    // Info props
    public string Name { get; set; }
    public string Description { get; set; }
    public byte Type { get; set; }
    
    // Min | Max props
    public int MinExp { get; set; }
    public int MaxExp { get; set; }
    public ushort MinEnergyCost { get; set; } 
    public ushort MaxEnergyCost { get; set; }
    public ushort MinDamage { get; set; }
    public ushort MaxDamage { get; set; }
}