using Api_LojaTricotllure.Data;
using Api_LojaTricotllure.Interfaces;
using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Models.DTO;
using Api_LojaTricotllure.Response;
using Api_LojaTricotllure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IUserService _userService;
    private readonly TokenService _tokenService;

    public UserController(AppDbContext context, IUserService userService, TokenService tokenService)
    {
        _context = context;
        _userService = userService;
        _tokenService = tokenService;
    }
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _userService.GetUserByEmailAndPassword(request.Email, request.Password);

        if (user == null)
            return Unauthorized("Email ou senha inválidos");

        var token = _tokenService.GenerateToken(user.Result);

        return Ok(new
        {
            token,
            user = new
            {
                user.Result.Id,
                user.Result.UserName,
                user.Result.Name,
                user.Result.Email,
                user.Result.PhoneDDD,
                user.Result.PrimaryPhone
            }
        });
    }
    
    [HttpGet]
    [Route("GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetUsers();
        
        return users.Result != null ? Ok(users) : NotFound();
    }
    
    [HttpGet]
    [Route("GetUserByEmailAndPassword")]
    public async Task<IActionResult> GetUserByEmailAndPassword([FromQuery] string email, [FromQuery] string password)
    {
        var users = await _userService.GetUserByEmailAndPassword(email, password);
        
        return users.Result != null ? Ok(users) : NotFound();
    }

    [HttpPost]
    [Route("CreateUser")]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        var createUser = await _userService.CreateUser(user);
        
        return createUser.Success
            ? Ok(createUser)
            : BadRequest(createUser);
    }

    [HttpPut]
    [Authorize]
    [Route("FirstAcessUser")]
    public async Task<IActionResult> FirstAcessUser([FromQuery] int userId)
    {
        var FirstAcessUser = await _userService.FirstAcessUser(userId);
        
        return FirstAcessUser.Success
            ? Ok(FirstAcessUser)
            : BadRequest();
    }
}