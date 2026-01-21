using Api_LojaTricotllure.Interfaces;
using Api_LojaTricotllure.Interfaces.Repository;
using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Response;

namespace Api_LojaTricotllure.Services;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly IUserRepository _userRepository;
    
    public UserService(ILogger<UserService> logger, IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    public async Task<CustomResponse<List<User>>> GetUsers(string email, string password)
    {
        try
        {
            var users = await _userRepository.GetUsers(email, password);

            return new CustomResponse<List<User>>(
                true,
                new List<string>(),
                users,
                users.Count
            );
        }
        catch (Exception ex)
        {
            return new CustomResponse<List<User>>(
                false,
                new List<string> { ex.Message },
                null
            );
        }
    }
}