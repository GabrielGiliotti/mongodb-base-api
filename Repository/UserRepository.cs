using MongoDB.Bson;
using mongodb_base_api.Infrastructure.Database;
using mongodb_base_api.Models;

namespace mongodb_base_api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IRepository<User> _repository;
    
    public UserRepository(IRepository<User> repository) 
    {
        _repository = repository;
    }

    public async Task AddUser(User obj)
    {
        await _repository.Add(obj);
    }

    public async Task<User> GetUserById(ObjectId id)
    {
        return await _repository.GetById(id);
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _repository.GetAll();
    }

    public async Task RemoveUser(ObjectId id)
    {
        await _repository.Remove(id);
    }

    public async Task UpdateUser(User obj)
    {
        await _repository.Update(obj);
    }
}