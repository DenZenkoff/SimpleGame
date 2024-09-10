using MediatR;

namespace Application.UseCases.CQRS.Commands.Character.DeleteCharacter;

public class DeleteCharacterCommand : IRequest<bool>
{
    public int Id { get; set; }
}