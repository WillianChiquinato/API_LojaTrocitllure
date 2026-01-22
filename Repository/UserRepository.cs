using Api_LojaTricotllure.Data;
using Api_LojaTricotllure.Interfaces.Repository;
using Api_LojaTricotllure.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_LojaTricotllure.Repository;

public class UserRepository :  IUserRepository
{
    private readonly AppDbContext _efDbContext;

    public UserRepository(AppDbContext efDbContext)
    {
        _efDbContext = efDbContext;
    }
    
    public async Task<List<User>> GetUsers()
    {
        return await _efDbContext.Users
            .OrderByDescending(u => u.Id)
            .ToListAsync();
    }

    public async Task<User?> GetUserByEmailAndPassword(string email, string password)
    {
        return await _efDbContext.Users
            .Where(u => u.IsActive && u.Email == email && u.Password == password)
            .OrderByDescending(u => u.Id)
            .FirstOrDefaultAsync();
    }

    public async Task<User> CreateUser(User user)
    {
        var teste = user;
        _efDbContext.Users.Add(user);
        await _efDbContext.SaveChangesAsync();

        return user;
    }

    public async Task<User> FirstAcessUser(int id)
    {
        var getUserDestination = await _efDbContext.Users
            .FirstOrDefaultAsync(user => user.Id == id);

        if (getUserDestination == null)
        {
            return null;
        }
        
        //Updating User.
        getUserDestination.FirstAcess = DateTime.UtcNow;
        getUserDestination.UpdatedAt = DateTime.UtcNow;
        
        _efDbContext.Users.Update(getUserDestination);
        await _efDbContext.SaveChangesAsync();
        
        return getUserDestination;
    }

    public async Task<User?> ReadUserByCPF(string cpf_cnpj)
    {
        return await _efDbContext.Users.SingleOrDefaultAsync(ac => ac.CpfCnpj == cpf_cnpj);
    }

    public async Task<User?> ReadUserWithEmail(string email)
    {
        return await _efDbContext.Users.SingleOrDefaultAsync(ac => ac.Email == email);
    }
}