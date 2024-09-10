using Domain.Entities;
using MediatR;

namespace Application.UseCases.CQRS.Queries.Action.GetActionById;

public class GetActionByIdQuery : IRequest<ActionEntity>
{
    public int Id { get; set; }
}