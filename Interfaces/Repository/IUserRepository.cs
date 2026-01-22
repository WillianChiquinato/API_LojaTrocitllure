using Api_LojaTricotllure.Models;

namespace Api_LojaTricotllure.Interfaces.Repository;

public interface IUserRepository
{
    public Task<List<User>> GetUsers();
    public Task<User> GetUserByEmailAndPassword(string email, string password);
    public Task<User> CreateUser(User user);
    public Task<User> FirstAcessUser(int id);
    public Task<User> ReadUserByCPF(string cpf_cnpj);
    public Task<User> ReadUserWithEmail(string email);
}