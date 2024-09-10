using System.Data;
using Application.Interfaces.Repositories;
using Dapper;
using Domain.Entities;
using Infrastructure.DapperQueries.MySql.Queries;
using Infrastructure.DapperQueries.Types;

namespace Infrastructure.Interfaces.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;
    
    public CharacterRepository(IDbConnection connection, IDbTransaction transaction)
    {
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        _transaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
    }
    
    public async Task<int> InsertAsync(CharacterEntity entity)
    {
        return await _connection.ExecuteScalarAsync<int>(
            sql: CharacterQuery.Queries[CharacterQueryType.Insert], 
            param: entity, 
            transaction: _transaction);
    }

    public async Task<bool> UpdateAsync(CharacterEntity entity)
    {
        return await _connection.ExecuteAsync(
            sql: CharacterQuery.Queries[CharacterQueryType.Update],
            param: entity,
            transaction: _transaction) > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _connection.ExecuteAsync(
            sql: CharacterQuery.Queries[CharacterQueryType.Delete],
            param: new { Id = id },
            transaction: _transaction) > 0;
    }

    public async Task<CharacterEntity?> GetByIdAsync(int id)
    {
        return (await _connection.QueryAsync<CharacterEntity, StatsEntity, CharacterEntity>(
            sql: CharacterQuery.Queries[CharacterQueryType.SelectById],
            map: (chr, st) =>
            {
                chr.Stats = st;
                return chr;
            },
            splitOn: "characterId",
            param: new { Id = id },
            transaction: _transaction)).FirstOrDefault();
    }

    public async Task<IEnumerable<CharacterEntity>> GetAllAsync()
    {
        return await _connection.QueryAsync<CharacterEntity, StatsEntity, CharacterEntity>(
            sql: CharacterQuery.Queries[CharacterQueryType.Select],
            map: (chr, st) =>
            {
                chr.Stats = st;
                return chr;
            },
            splitOn: "characterId",
            transaction: _transaction);
    }

    public async Task<IEnumerable<CharacterEntity>> GetAllTheDeadAsync()
    {
        return await _connection.QueryAsync<CharacterEntity, StatsEntity, CharacterEntity>(
            sql: CharacterQuery.Queries[CharacterQueryType.SelectAllTheDead],
            map: (chr, st) =>
            {
                chr.Stats = st;
                return chr;
            },
            splitOn: "characterId",
            transaction: _transaction);
    }
}