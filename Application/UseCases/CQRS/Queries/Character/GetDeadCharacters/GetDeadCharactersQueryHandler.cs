using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.CQRS.Queries.Character.GetDeadCharacters;

public class GetDeadCharactersQueryHandler : IRequestHandler<GetDeadCharactersQuery, IEnumerable<CharacterEntity>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDeadCharactersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<IEnumerable<CharacterEntity>> Handle(GetDeadCharactersQuery request, CancellationToken cancellationToken)
    {
        var characterEntities = await _unitOfWork.CharacterRepository.GetAllTheDeadAsync();
        
        return characterEntities;
    }
}