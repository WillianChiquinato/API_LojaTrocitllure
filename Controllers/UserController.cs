using Api_LojaTricotllure.Data;
using Api_LojaTricotllure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IUserService _userService;

    public UserController(AppDbContext context, IUserService userService)
    {
        _context = context;
        _userService = userService;
    }

    [HttpGet]
    [Route("GetUsers")]
    public async Task<IActionResult> GetUsers([FromQuery] string email, [FromQuery] string password)
    {
        var users = await _userService.GetUsers(email, password);
        
        return users.Result != null ? Ok(users) : NotFound();
    }
}