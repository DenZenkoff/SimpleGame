using Application.Enums;

namespace Application.Dtos.Responses;

public class GetCharacterResponseDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public Race Race { get; set; }
    public Gender Gender { get; set; }
    public Class Class { get; set; }
    public bool IsAlive { get; set; }
    
    public ushort Level { get; set; }
    public int CurrentExp { get; set; }
    public int LevelExp { get; set; }
    
    public GetStatsResponseDto Stats { get; set; }
}