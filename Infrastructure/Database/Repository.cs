using MongoDB.Bson;
using MongoDB.Driver;
using mongodb_base_api.Models;

namespace mongodb_base_api.Infrastructure.Database;

public class Repository<T> : IRepository<T> where T : Default
{
    protected readonly IMongoContext _context;
    protected readonly IMongoCollection<T> _collection;

    public Repository(IMongoContext context)
    {
        _context = context;
        _collection = _context.GetCollection<T>(typeof(T).Name);
    }

    public virtual async Task Add(T obj)
    {
        await _collection.InsertOneAsync(obj);
    }

    public virtual async Task<T> GetById(ObjectId id)
    {
        var data = await _collection.FindAsync(Builders <T>.Filter.Eq("_id", id));
        return data.FirstOrDefault();
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        var all = await _collection.FindAsync(Builders<T>.Filter.Empty);
        return all.ToList();
    }

    public virtual async Task Update(T obj)
    {
        await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", new ObjectId(obj.Id)), obj);
    }

    public virtual async Task Remove(ObjectId id) 
    {
        await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
    }

    public virtual void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}