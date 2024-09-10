using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.CQRS.Commands.Character.UpdateCharacter;

public class UpdateCharacterCommandHandler : IRequestHandler<UpdateCharacterCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCharacterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<bool> Handle(UpdateCharacterCommand request, CancellationToken cancellationToken)
    {
        var characterEntity = _mapper.Map<CharacterEntity>(request);
        var characterUpdated = await _unitOfWork.CharacterRepository.UpdateAsync(characterEntity);

        var statsEntity = _mapper.Map<StatsEntity>(request.Stats);
        statsEntity.CharacterId = request.Id;
        var statsUpdated = await _unitOfWork.StatsRepository.UpdateAsync(statsEntity);

        var result = characterUpdated && statsUpdated;
        
        if (result)
            await _unitOfWork.CommitAsync();
        else
            await _unitOfWork.RollbackAsync();
        
        return result;
    }
}