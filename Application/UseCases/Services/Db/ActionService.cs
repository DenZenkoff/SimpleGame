using Application.Models;
using Application.UseCases.CQRS.Commands.Action.CreateAction;
using Application.UseCases.CQRS.Commands.Action.DeleteAction;
using Application.UseCases.CQRS.Commands.Action.UpdateAction;
using Application.UseCases.CQRS.Queries.Action.GetActionById;
using Application.UseCases.CQRS.Queries.Action.GetActions;
using Application.UseCases.Services.Db.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Services.Db;

public class ActionService : IActionService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ActionService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<bool> AddAsync(ActionModel actionModelDto)
    {
        var command = _mapper.Map<CreateActionCommand>(actionModelDto);
        var isCreated = await _mediator.Send(command);
        return isCreated;
    }
    
    public async Task<bool> UpdateAsync(ActionModel actionModelDto)
    {
        var command = _mapper.Map<UpdateActionCommand>(actionModelDto);
        var isUpdated = await _mediator.Send(command);
        return isUpdated;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var isDeleted = await _mediator.Send(new DeleteActionCommand { Id = id });
        return isDeleted;
    }
    
    public async Task<ActionModel> GetByIdAsync(int id)
    {
        var result = await _mediator.Send(new GetActionByIdQuery { Id = id });
        return _mapper.Map<ActionModel>(result);
    }
    
    public async Task<IList<ActionModel>> GetAllAsync()
    {
        var result = await _mediator.Send(new GetActionsQuery());
        return _mapper.Map<IList<ActionModel>>(result);
    }
}