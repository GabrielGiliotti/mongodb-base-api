using MongoDB.Driver;
using Microsoft.Extensions.Options;
using mongodb_base_api.Infrastructure.System.Models;

namespace mongodb_base_api.Infrastructure.Database;

public class MongoContext : IMongoContext 
{
    private readonly IMongoDatabase _db;

    public MongoContext(IOptions<Settings> config) 
    {
        var client = new MongoClient(config.Value.ConnectionString);
        _db = client.GetDatabase(config.Value.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _db.GetCollection<T>(name);
    }
}