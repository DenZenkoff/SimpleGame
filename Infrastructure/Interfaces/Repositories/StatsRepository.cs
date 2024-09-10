using System.Data;
using Application.Interfaces.Repositories;
using Dapper;
using Domain.Entities;
using Infrastructure.DapperQueries.MySql.Queries;
using Infrastructure.DapperQueries.Types;

namespace Infrastructure.Interfaces.Repositories;

public class StatsRepository : IStatsRepository
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;
    
    public StatsRepository(IDbConnection connection, IDbTransaction transaction)
    {
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        _transaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
    }
    
    public async Task<int> InsertAsync(StatsEntity entity)
    {
        return await _connection.ExecuteScalarAsync<int>(
            sql: StatsQuery.Queries[StatsQueryType.Insert],
            param: entity,
            transaction: _transaction);
    }

    public async Task<bool> UpdateAsync(StatsEntity entity)
    {
        return await _connection.ExecuteAsync(
            sql: StatsQuery.Queries[StatsQueryType.Update],
            param: entity,
            transaction: _transaction) > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _connection.ExecuteAsync(
            sql: StatsQuery.Queries[StatsQueryType.Delete],
            param: new { CharacterId = id },
            transaction: _transaction) > 0;
    }
}