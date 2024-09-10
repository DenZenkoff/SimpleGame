using Application.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.CQRS.Commands.Action.DeleteAction;

public class DeleteActionCommandHandler : IRequestHandler<DeleteActionCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteActionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    
    public async Task<bool> Handle(DeleteActionCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ActionRepository.DeleteAsync(request.Id);
        
        if (result)
            await _unitOfWork.CommitAsync();
        else
            await _unitOfWork.RollbackAsync();
        
        return result;
    }
}