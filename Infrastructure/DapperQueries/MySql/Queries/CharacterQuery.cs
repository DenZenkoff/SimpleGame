using Infrastructure.DapperQueries.Types;

namespace Infrastructure.DapperQueries.MySql.Queries;

public static class CharacterQuery
{
    private const string CharacterTable = TableName.CharacterTable;
    private const string StatsTable = TableName.StatsTable;

    public static readonly Dictionary<int, string> Queries = new()
    {
        // Queries
        { CharacterQueryType.Select, $"SELECT * FROM {CharacterTable} chr INNER JOIN {StatsTable} st ON chr.id = st.characterId" },
        { CharacterQueryType.SelectById, $"SELECT * FROM {CharacterTable} chr INNER JOIN {StatsTable} st ON chr.id = st.characterId WHERE id = @Id" },
        { CharacterQueryType.SelectAllTheDead, $"SELECT * FROM {CharacterTable} chr INNER JOIN {StatsTable} st ON chr.id = st.characterId WHERE isAlive = false" },
        
        // Commands
        {
            CharacterQueryType.Insert,
            $"INSERT INTO {CharacterTable} (name, race, gender, class, isAlive, level, currentExp, levelExp)" +
            $" VALUES (@Name, @Race, @Gender, @Class, @IsAlive, @Level, @CurrentExp, @LevelExp);" +
            $" SELECT LAST_INSERT_ID()"
        },
        {
            CharacterQueryType.Update,
            $"UPDATE {CharacterTable} SET " +
            $" name = @Name, race = @Race, " +
            $" gender = @Gender, class = @Class," +
            $" isAlive = @IsAlive, level = @Level," +
            $" currentExp = @CurrentExp, levelExp = @LevelExp" +
            $" WHERE id = @Id"
        },
        { CharacterQueryType.Delete, $"DELETE FROM {CharacterTable} WHERE id = @Id" },
    };
}