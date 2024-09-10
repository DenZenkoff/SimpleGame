using System.Data;
using Application.Interfaces.Repositories;
using Dapper;
using Domain.Entities;
using Infrastructure.DapperQueries.MySql.Queries;
using Infrastructure.DapperQueries.Types;

namespace Infrastructure.Interfaces.Repositories;

public class ActionRepository : IActionRepository
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;
    
    public ActionRepository(IDbConnection connection, IDbTransaction transaction)
    {
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        _transaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
    }
    
    public async Task<int> InsertAsync(ActionEntity entity)
    {
        return await _connection.ExecuteAsync(
            sql: ActionQuery.Queries[ActionQueryType.Insert], 
            param: entity, 
            transaction: _transaction);
    }

    public async Task<bool> UpdateAsync(ActionEntity entity)
    {
        return await _connection.ExecuteAsync(
            sql: ActionQuery.Queries[ActionQueryType.Update],
            param: entity,
            transaction: _transaction) > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _connection.ExecuteAsync(
            sql: ActionQuery.Queries[ActionQueryType.Delete],
            param: new { Id = id },
            transaction: _transaction) > 0;
    }

    public async Task<ActionEntity?> GetByIdAsync(int id)
    {
        return await _connection.QueryFirstOrDefaultAsync<ActionEntity>(
            sql: ActionQuery.Queries[ActionQueryType.SelectById], 
            param: new { Id = id }, 
            transaction: _transaction);
    }

    public async Task<IEnumerable<ActionEntity>> GetAllAsync()
    {
        return await _connection.QueryAsync<ActionEntity>(
            sql: ActionQuery.Queries[ActionQueryType.Select], 
            transaction: _transaction);
    }
}