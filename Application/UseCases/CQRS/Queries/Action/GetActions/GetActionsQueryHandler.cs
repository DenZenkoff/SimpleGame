using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.CQRS.Queries.Action.GetActions;

public class GetActionsQueryHandler : IRequestHandler<GetActionsQuery, IEnumerable<ActionEntity>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetActionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<ActionEntity>> Handle(GetActionsQuery request, CancellationToken cancellationToken)
    {
        var actionsEntities = await _unitOfWork.ActionRepository.GetAllAsync();

        return actionsEntities;
    }
}