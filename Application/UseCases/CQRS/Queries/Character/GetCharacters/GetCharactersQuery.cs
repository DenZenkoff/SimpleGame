using Domain.Entities;
using MediatR;

namespace Application.UseCases.CQRS.Queries.Character.GetCharacters;

public class GetCharactersQuery : IRequest<IEnumerable<CharacterEntity>>
{
    
}