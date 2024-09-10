using Application.Enums;

namespace Application.Dtos.Requests;

public class CharacterCreateRequestDto
{
    public string Name { get; set; }
    public Race Race { get; set; }
    public Gender Gender { get; set; }
    public Class Class { get; set; }
}