using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.CQRS.Commands.Action.CreateAction;

public class CreateActionCommandHandler : IRequestHandler<CreateActionCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateActionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<bool> Handle(CreateActionCommand request, CancellationToken cancellationToken)
    {
        var actionEntity = _mapper.Map<ActionEntity>(request);
        var result = await _unitOfWork.ActionRepository.InsertAsync(actionEntity) > 0;
        
        if (result)
            await _unitOfWork.CommitAsync();
        else
            await _unitOfWork.RollbackAsync();

        return result;
    }
}