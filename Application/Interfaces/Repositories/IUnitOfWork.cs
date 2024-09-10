namespace Application.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    // Repositories
    IActionRepository ActionRepository { get; }
    ICharacterRepository CharacterRepository { get; }
    IStatsRepository StatsRepository { get; }

    // Methods
    Task CommitAsync();
    Task RollbackAsync();
}
