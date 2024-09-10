namespace Application.Interfaces.Repositories;

public interface ICommandRepository<T> where T : class
{
    Task<int> InsertAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
}