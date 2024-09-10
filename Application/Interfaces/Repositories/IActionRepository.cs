using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IActionRepository : ICommandRepository<ActionEntity>, IQueryRepository<ActionEntity>
{
    
}