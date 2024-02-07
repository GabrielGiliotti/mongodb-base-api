using mongodb_base_api.Models;

namespace mongodb_base_api.Repository;

public interface IUserRepository
{
    Task AddUser(User obj);
    Task<User> GetUserById(Guid id);
    Task<IEnumerable<User>> GetUsers();
    Task UpdateUser(User obj);
    Task RemoveUser(Guid id);
}