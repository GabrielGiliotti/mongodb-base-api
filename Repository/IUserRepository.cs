using MongoDB.Bson;
using mongodb_base_api.Models;

namespace mongodb_base_api.Repositories;

public interface IUserRepository
{
    Task AddUser(User obj);
    Task<User> GetUserById(ObjectId id);
    Task<IEnumerable<User>> GetUsers();
    Task UpdateUser(User obj);
    Task RemoveUser(ObjectId id);
}