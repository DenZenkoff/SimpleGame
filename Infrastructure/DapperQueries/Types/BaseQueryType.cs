namespace Infrastructure.DapperQueries.Types;

public abstract class BaseQueryType
{
    public const int Select = 1;
    public const int SelectById = 2;

    public const int Insert = 3;
    public const int Update = 4;
    public const int Delete = 5;
}