namespace Hotel.Core.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAsync(bool onlyActives = false);
    Task<T?> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}