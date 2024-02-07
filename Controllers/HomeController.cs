using Microsoft.AspNetCore.Mvc;

namespace mongodb_base_api.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetHome()
    {
        var msg = $"Welcome ! API Started at {DateTime.Now.ToLongTimeString()}";
        _logger.LogInformation(msg);

        return Ok(msg);
    }
}