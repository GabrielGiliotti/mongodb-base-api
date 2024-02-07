using MongoDB.Driver;

namespace mongodb_base_api.Infrastructure.Database;

public interface IMongoContext
{
    public IMongoCollection<T> GetCollection<T>(string name);
}