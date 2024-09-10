namespace Application.UseCases.CQRS.Commands.Character.UpdateCharacter;

public class UpdateStatsCommand
{
    public ushort Strength { get; set; }
    public ushort Speed { get; set; }
    public ushort Intelligence { get; set; }
    
    public ushort MaxHp { get; set; }
    public ushort CurrentHp { get; set; }
    public ushort MaxEnergy { get; set; }
    public ushort CurrentEnergy { get; set; }
}