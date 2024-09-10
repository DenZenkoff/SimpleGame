using Domain.Entities;
using MediatR;

namespace Application.UseCases.CQRS.Queries.Character.GetCharacterById;

public class GetCharacterByIdQuery : IRequest<CharacterEntity>
{
    public int Id { get; set; }
}