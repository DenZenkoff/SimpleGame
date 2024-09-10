using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.CQRS.Queries.Character.GetCharacterById;

public class GetCharacterByIdQueryHandler : IRequestHandler<GetCharacterByIdQuery, CharacterEntity>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCharacterByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    
    public async Task<CharacterEntity> Handle(GetCharacterByIdQuery request, CancellationToken cancellationToken)
    {
        var characterEntity = await _unitOfWork.CharacterRepository.GetByIdAsync(request.Id);
        
        return characterEntity ?? new CharacterEntity();
    }
}