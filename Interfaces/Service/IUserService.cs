using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Response;

namespace Api_LojaTricotllure.Interfaces;

public interface IUserService
{
    public Task<CustomResponse<List<User>>> GetUsers(string email, string password);
}