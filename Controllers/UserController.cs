using Microsoft.AspNetCore.Mvc;
using mongodb_base_api.DTOs;
using mongodb_base_api.Services;

namespace mongodb_base_api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(UserDto user)
    {
        await _userService.AddUser(user);
        return Ok("New user registered");
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await _userService.GetUsers());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUsers(string id)
    {
        return Ok(await _userService.GetUserById(id));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(UserUpdateDto user)
    {
        await _userService.UpdateUser(user);
        return Ok("User updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        await _userService.RemoveUser(id);
        return Ok("User deleted");
    }
}