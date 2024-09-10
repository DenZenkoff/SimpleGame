namespace Application.UseCases.Services.Db.Interfaces;

public interface IService<T>
{
    Task<bool> AddAsync(T request);
    Task<bool> UpdateAsync(T request);
    Task<bool> DeleteAsync(int id);
    Task<T> GetByIdAsync(int id);
    Task<IList<T>> GetAllAsync();
}