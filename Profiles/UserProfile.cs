using AutoMapper;
using mongodb_base_api.DTOs;
using mongodb_base_api.Models;

namespace mongodb_base_api.Profiles;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<UserUpdateDto, User>();
        CreateMap<User, UserUpdateDto>();
        CreateMap<IEnumerable<User>, List<UserDto>>();
    }
}