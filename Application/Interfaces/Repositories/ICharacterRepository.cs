using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface ICharacterRepository : ICommandRepository<CharacterEntity>, IQueryRepository<CharacterEntity>
{
    Task<IEnumerable<CharacterEntity>> GetAllTheDeadAsync();
}