using Application.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.CQRS.Commands.Character.DeleteCharacter;

public class DeleteCharacterCommandHandler : IRequestHandler<DeleteCharacterCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCharacterCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    
    public async Task<bool> Handle(DeleteCharacterCommand request, CancellationToken cancellationToken)
    {
        var areStatsDeleted = await _unitOfWork.StatsRepository.DeleteAsync(request.Id);
        var isCharacterDeleted = await _unitOfWork.CharacterRepository.DeleteAsync(request.Id);
        
        var result = areStatsDeleted && isCharacterDeleted;
        
        if (result)
            await _unitOfWork.CommitAsync();
        else
            await _unitOfWork.RollbackAsync();
        
        return result;
    }
}