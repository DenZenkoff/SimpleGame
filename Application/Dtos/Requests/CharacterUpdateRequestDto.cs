namespace Application.Dtos.Requests;

public class CharacterUpdateRequestDto : CharacterCreateRequestDto
{
    public int Id { get; set; }
    
    public bool IsAlive { get; set; }
    
    public ushort Level { get; set; }
    public int CurrentExp { get; set; }
    public int LevelExp { get; set; }
    
    public StatsUpdateRequestDto Stats { get; set; }
}