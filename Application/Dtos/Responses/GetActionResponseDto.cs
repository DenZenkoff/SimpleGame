using Application.Enums;

namespace Application.Dtos.Responses;

public class GetActionResponseDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public ActionType ActionType { get; set; }
    
    public int MinExp { get; set; }
    public int MaxExp { get; set; }
    public ushort MinEnergyCost { get; set; } 
    public ushort MaxEnergyCost { get; set; }
    public ushort MinDamage { get; set; }
    public ushort MaxDamage { get; set; }
}