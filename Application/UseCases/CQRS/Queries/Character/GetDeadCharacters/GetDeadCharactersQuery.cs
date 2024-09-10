using Domain.Entities;
using MediatR;

namespace Application.UseCases.CQRS.Queries.Character.GetDeadCharacters;

public class GetDeadCharactersQuery : IRequest<IEnumerable<CharacterEntity>>
{
    
}