using Api_LojaTricotllure.Models;

namespace Api_LojaTricotllure.Interfaces.Repository;

public interface IUserRepository
{
    public Task<List<User>> GetUsers(string email, string password);
}