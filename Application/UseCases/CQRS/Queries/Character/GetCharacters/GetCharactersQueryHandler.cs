using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.CQRS.Queries.Character.GetCharacters;

public class GetCharactersQueryHandler : IRequestHandler<GetCharactersQuery, IEnumerable<CharacterEntity>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCharactersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    
    public async Task<IEnumerable<CharacterEntity>> Handle(GetCharactersQuery request, CancellationToken cancellationToken)
    {
        var characterEntities = await _unitOfWork.CharacterRepository.GetAllAsync();
        
        return characterEntities;
    }
}