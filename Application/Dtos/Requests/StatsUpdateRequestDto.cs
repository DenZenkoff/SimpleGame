namespace Application.Dtos.Requests;

public class StatsUpdateRequestDto
{
    public ushort Strength { get; set; }
    public ushort Speed { get; set; }
    public ushort Intelligence { get; set; }
    
    public ushort MaxHp { get; set; }
    public ushort CurrentHp { get; set; }
    public ushort MaxEnergy { get; set; }
    public ushort CurrentEnergy { get; set; }
}