using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Response;

namespace Api_LojaTricotllure.Interfaces;

public interface IUserService
{
    public Task<CustomResponse<List<User>>> GetUsers();
    public Task<CustomResponse<User>> GetUserByEmailAndPassword(string email, string password);
    public Task<CustomResponse<User>> CreateUser(User user);
    public Task<CustomResponse<User>> FirstAcessUser(int id);
}