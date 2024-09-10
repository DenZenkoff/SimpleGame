using MediatR;

namespace Application.UseCases.CQRS.Commands.Action.DeleteAction;

public class DeleteActionCommand : IRequest<bool>
{
    public int Id { get; set; }
}