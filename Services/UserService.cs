using MongoDB.Bson;
using mongodb_base_api.DTOs;
using mongodb_base_api.Models;
using mongodb_base_api.Repositories;

namespace mongodb_base_api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository) 
    {
        _userRepository = userRepository;
    }

    public async Task AddUser(UserDto obj)
    {
        var user = new User 
        {
            Name = obj.Name,
            Email = obj.Email,
            Password = obj.Password,
            IsActive = obj.IsActive,
            CreatedAt = obj.CreatedAt
        };

        await _userRepository.AddUser(user);
    }

    public async Task<UserDto> GetUserById(string id)
    {
        var user = await _userRepository.GetUserById(new ObjectId(id));

        var dto = new UserDto 
        {
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            IsActive = user.IsActive,
            CreatedAt = user.CreatedAt
        };

        return dto;
    }

    public async Task<IEnumerable<UserDto>> GetUsers()
    {
        var users = await _userRepository.GetUsers();
        var list = new List<UserDto>();

        foreach (var user in users) 
        {
            var dto = new UserDto 
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt
            };

            list.Add(dto);
        }
        
        return list;
    }

    public async Task RemoveUser(string id)
    {
        await _userRepository.RemoveUser(new ObjectId(id));
    }

    public async Task UpdateUser(UserUpdateDto obj)
    {
        var user = new User 
        {
            Id = obj.Id,
            Name = obj.Name,
            Email = obj.Email,
            Password = obj.Password,
            IsActive = obj.IsActive,
            CreatedAt = obj.CreatedAt
        };

        await _userRepository.UpdateUser(user);
    }
}