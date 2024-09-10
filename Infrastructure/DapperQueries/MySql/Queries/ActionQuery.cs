using Infrastructure.DapperQueries.Types;

namespace Infrastructure.DapperQueries.MySql.Queries;

public static class ActionQuery
{
    private const string ActionTable = TableName.ActionTable;

    public static readonly Dictionary<int, string> Queries = new()
    {
        // Queries
        { ActionQueryType.Select, $"SELECT * FROM {ActionTable}" },
        { ActionQueryType.SelectById, $"SELECT * FROM {ActionTable} WHERE id = @Id" },

        // Commands
        {
            ActionQueryType.Insert,
            $"INSERT INTO {ActionTable} (name, description, type, minExp, maxExp, minEnergyCost, maxEnergyCost, minDamage, maxDamage)" +
            $" VALUES (@Name, @Description, @Type, @MinExp, @MaxExp, @MinEnergyCost, @MaxEnergyCost, @MinDamage, @MaxDamage);" +
            $" SELECT LAST_INSERT_ID()"
        },
        {
            ActionQueryType.Update,
            $"UPDATE {ActionTable} SET " +
            $" name = @Name, description = @Description, type = @Type," +
            $" minExp = @MinExp, maxExp = @MaxExp," +
            $" minEnergyCost = @MinEnergyCost, maxEnergyCost = @MaxEnergyCost," +
            $" minDamage = @MinDamage, maxDamage = @MaxDamage" +
            $" WHERE id = @Id"
        },
        { ActionQueryType.Delete, $"DELETE FROM {ActionTable} WHERE id = @Id" },
    };
}