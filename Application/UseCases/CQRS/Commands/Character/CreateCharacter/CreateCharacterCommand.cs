using Application.Enums;
using MediatR;

namespace Application.UseCases.CQRS.Commands.Character.CreateCharacter;

public class CreateCharacterCommand : IRequest<bool>
{
    public string Name { get; set; }
    public Race Race { get; set; }
    public Gender Gender { get; set; }
    public Class Class { get; set; }
}