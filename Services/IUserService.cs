using mongodb_base_api.DTOs;

namespace mongodb_base_api.Services;

public interface IUserService
{
    Task AddUser(UserDto obj);
    Task<UserDto> GetUserById(string id);
    Task<IEnumerable<UserDto>> GetUsers();
    Task UpdateUser(UserDto obj);
    Task RemoveUser(string id);
}