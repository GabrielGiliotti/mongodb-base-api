using AutoMapper;
using MongoDB.Bson;
using mongodb_base_api.DTOs;
using mongodb_base_api.Models;
using mongodb_base_api.Repositories;

namespace mongodb_base_api.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository, IMapper mapper) 
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task AddUser(UserDto obj)
    {
        var user = _mapper.Map<User>(obj);

        if(user != null)
            await _userRepository.AddUser(user);
        else
            throw new Exception("Error when adding User");
    }

    public async Task<UserDto> GetUserById(string id)
    {
        var user = await _userRepository.GetUserById(new ObjectId(id));

        var dto = _mapper.Map<UserDto>(user);

        if(dto != null)
            return dto;
        else 
            throw new Exception("Error while mapping UserDto");
    }

    public async Task<IEnumerable<UserDto>> GetUsers()
    {
        var users = await _userRepository.GetUsers();
        
        var list = _mapper.Map<IEnumerable<UserDto>>(users);

        if(list != null)
            return list;
        else 
            throw new Exception("Error while mapping User List");
    }

    public async Task RemoveUser(string id)
    {
        await _userRepository.RemoveUser(new ObjectId(id));
    }

    public async Task UpdateUser(UserUpdateDto obj)
    {
        var user = _mapper.Map<User>(obj);

        if(user != null)
            await _userRepository.UpdateUser(user);
        else
            throw new Exception("Error when updating User");
    }
}