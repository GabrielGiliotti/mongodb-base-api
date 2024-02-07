using MongoDB.Driver;
using mongodb_base_api.Models;

namespace mongodb_base_api.Infrastructure.Database;

public abstract class Repository<T> : IRepository<T> where T : Default
{
    protected readonly IMongoContext _context;
    protected readonly IMongoCollection<T> DbSet;

    protected Repository(IMongoContext context)
    {
        _context = context;
        DbSet = _context.GetCollection<T>(typeof(T).Name);
    }

    public async Task Add(T obj)
    {
        await DbSet.InsertOneAsync(obj);
    }

    public async Task<T> GetById(Guid id)
    {
        var data = await DbSet.FindAsync(Builders <T>.Filter.Eq("_id", id));
        return data.FirstOrDefault();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        var all = await DbSet.FindAsync(Builders<T>.Filter.Empty);
        return all.ToList();
    }

    public async Task Update(T obj)
    {
        await DbSet.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", obj.Id), obj);
    }

    public async Task Remove(Guid id) 
    {
        await DbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}