namespace Application.Interfaces.Repositories;

public interface IQueryRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
}