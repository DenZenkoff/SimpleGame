using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.CQRS.Queries.Action.GetActionById;

public class GetActionByIdQueryHandler : IRequestHandler<GetActionByIdQuery, ActionEntity>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetActionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ActionEntity> Handle(GetActionByIdQuery request, CancellationToken cancellationToken)
    {
        var actionEntity = await _unitOfWork.ActionRepository.GetByIdAsync(request.Id);
        
        return actionEntity ?? new ActionEntity();
    }
}