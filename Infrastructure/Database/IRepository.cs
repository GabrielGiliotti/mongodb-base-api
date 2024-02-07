namespace mongodb_base_api.Infrastructure.Database;

public interface IRepository<T> : IDisposable where T : class
{
    Task Add(T obj);
    Task<T> GetById(Guid id);
    Task<IEnumerable<T>> GetAll();
    Task Update(T obj);
    Task Remove(Guid id);
}