using System.Data;
using Application.Interfaces.Repositories;

namespace Infrastructure.Interfaces.Repositories;

public class UnitOfWork : IUnitOfWork
{
    // Repositories
    public IActionRepository ActionRepository { get; }
    public ICharacterRepository CharacterRepository { get; }
    public IStatsRepository StatsRepository { get; }

    // Db connection
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;

    // GC
    private bool _disposed;

    public UnitOfWork(IDbConnection connection)
    {
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        _connection.Open();
        _transaction = _connection.BeginTransaction();
        
        ActionRepository = new ActionRepository(_connection, _transaction);
        CharacterRepository = new CharacterRepository(_connection, _transaction);
        StatsRepository = new StatsRepository(_connection, _transaction);
    }

    public Task CommitAsync()
    {
        _transaction.Commit();
        _transaction.Dispose();
        
        return Task.CompletedTask;
    }
    
    public Task RollbackAsync()
    {
        _transaction.Rollback();
        _transaction.Dispose();
        
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        
        if (disposing)
        {
            _transaction.Dispose();
            _connection.Dispose();
        }
        
        _disposed = true;
    }
}