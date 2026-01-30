using System.Security.Claims;
using Api_LojaTricotllure.Data;
using Api_LojaTricotllure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IUserService _userService;

    public AuthController(AppDbContext context, IUserService userService)
    {
        _context = context;
        _userService = userService;
    }

    [HttpGet]
    // [Authorize]
    [Route("Logged")]
    public async Task<IActionResult> Logged()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userIdClaim))
            return Unauthorized();

        var user = await _userService.GetById(int.Parse(userIdClaim));

        if (user == null)
            return Unauthorized();

        return Ok(new
        {
            user
        });
    }
}