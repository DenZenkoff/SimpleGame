using Application.Enums;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.CQRS.Commands.Character.CreateCharacter;

public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCharacterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<bool> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
    {
        var characterEntity = SetDefaultCharacter(_mapper.Map<CharacterEntity>(request));
        var characterId = await _unitOfWork.CharacterRepository.InsertAsync(characterEntity);
        
        if (characterId == 0)
        {
            await _unitOfWork.RollbackAsync();
            return false;
        }
        
        var statsEntity = SetDefaultStats(characterId, request.Class);
        var statsId = await _unitOfWork.StatsRepository.InsertAsync(statsEntity);
        
        var result = characterId > 0 && statsId == characterId;
        
        if (result)
            await _unitOfWork.CommitAsync();
        else
            await _unitOfWork.RollbackAsync();
        
        return result;
    }

    private CharacterEntity SetDefaultCharacter(CharacterEntity entity)
    {
        entity.IsAlive = true;
        entity.Level = 1;
        entity.LevelExp = 10;
        entity.CurrentExp = 0;

        return entity;
    }
    
    private StatsEntity SetDefaultStats(int characterId, Class prof)
    {
        var stats = new StatsEntity();
        stats.CharacterId = characterId;
        stats.MaxEnergy = 100;
        stats.CurrentEnergy = 100;

        switch (prof)
        {
            case Class.Warrior:
                stats.Strength = 3;
                stats.Speed = 1;
                stats.Intelligence = 1;
                stats.MaxHp = 15;
                stats.CurrentHp = 15;
                return stats;
            case Class.Rogue: 
                stats.Strength = 1;
                stats.Speed = 3;
                stats.Intelligence = 1;
                stats.MaxHp = 10;
                stats.CurrentHp = 10;
                return stats;
            case Class.Mage:
                stats.Strength = 1;
                stats.Speed = 1;
                stats.Intelligence = 3;
                stats.MaxHp = 5;
                stats.CurrentHp = 5;
                return stats;
            default:
                return new StatsEntity();
        }
    }
}