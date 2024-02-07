using Microsoft.AspNetCore.Mvc;
using mongodb_base_api.Models;
using mongodb_base_api.Repository;

namespace mongodb_base_api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(User user)
    {
        await _userRepository.AddUser(user);
        return Ok("New user registered");
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await _userRepository.GetUsers());
    }


}