using mongodb_base_api.Infrastructure.Database;
using mongodb_base_api.Models;

namespace mongodb_base_api.Repository;

public class UserRepository : IUserRepository
{
    private readonly IRepository<User> _userRepository;
    
    public UserRepository(IRepository<User> userRepository) 
    {
        _userRepository = userRepository;
    }

    public async Task AddUser(User obj)
    {
        await _userRepository.Add(obj);
    }

    public async Task<User> GetUserById(Guid id)
    {
        return await _userRepository.GetById(id);
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _userRepository.GetAll();
    }

    public async Task RemoveUser(Guid id)
    {
        await _userRepository.Remove(id);
    }

    public async Task UpdateUser(User obj)
    {
        await _userRepository.Update(obj);
    }
}