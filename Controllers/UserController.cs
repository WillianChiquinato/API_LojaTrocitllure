using Api_LojaTricotllure.Data;
using Api_LojaTricotllure.Interfaces;
using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Models.DTO;
using Api_LojaTricotllure.Response;
using Api_LojaTricotllure.Services;
using Google.Apis.Auth;
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
    
    [HttpPost]
    [Route("Login")]
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
    
    [HttpPost]
    [Route("LoginGoogle")]
    public async Task<IActionResult> LoginWithGoogle([FromBody] GoogleLoginRequest request)
    {
        var payload = await GoogleJsonWebSignature.ValidateAsync(
            request.token,
            new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { "163593940017-ci68c09h7pvot2i66i6nv7bd1o6soh45.apps.googleusercontent.com" }
            });

        var userResponse = await _userService.GoogleLogin(payload.Email);
        User user;

        if (userResponse.Result == null)
        {
            user = new User
            {
                UserName = payload.GivenName,
                Name = payload.Name,
                DocumentType = 2,
                Email = payload.Email,
                GoogleId = payload.Subject,
                FirstAcess = DateTime.Now,
                LastAcess = DateTime.Now,
                Sex = null,
                CpfCnpj = null,
                PhoneDDD = null,
                PrimaryPhone = null,
                DateOfBirth = null,
                Password = null,
            };

            var createResponse = await _userService.CreateUser(user);
            user = createResponse.Result;
        }
        else
        {
            user = userResponse.Result;
        }

        var jwt = _tokenService.GenerateToken(user);

        return Ok(new
        {
            token = jwt,
            user
        });
    }
    
    [HttpGet]
    [Authorize]
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