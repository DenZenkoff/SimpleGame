using Infrastructure.DapperQueries.Types;

namespace Infrastructure.DapperQueries.MySql.Queries;

public class StatsQuery
{
    private const string StatsTable = TableName.StatsTable;

    public static readonly Dictionary<int, string> Queries = new()
    {
        // Commands
        {
            StatsQueryType.Insert,
            $"INSERT INTO {StatsTable} (characterId, strength, speed, intelligence, maxHp, currentHp, maxEnergy, currentEnergy)" +
            $" VALUES (@CharacterId, @Strength, @Speed, @Intelligence, @MaxHp, @CurrentHp, @MaxEnergy, @CurrentEnergy);" +
            $" SELECT LAST_INSERT_ID()"
        },
        {
            StatsQueryType.Update,
            $"UPDATE {StatsTable} SET" +
            $" strength = @Strength, speed = @Speed, intelligence = @Intelligence," +
            $" maxHp = @MaxHp, currentHp = @CurrentHp," +
            $" maxEnergy = @MaxEnergy, currentEnergy = @CurrentEnergy" +
            $" WHERE characterId = @CharacterId"
        },
        { StatsQueryType.Delete, $"DELETE FROM {StatsTable} WHERE characterId = @CharacterId" },
    };
}