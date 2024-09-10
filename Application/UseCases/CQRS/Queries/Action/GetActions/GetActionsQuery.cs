using Domain.Entities;
using MediatR;

namespace Application.UseCases.CQRS.Queries.Action.GetActions;

public class GetActionsQuery : IRequest<IEnumerable<ActionEntity>>
{
    
}