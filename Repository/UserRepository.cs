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

    public async Task<List<User>> GetUsers(string email, string password)
    {
        return await _efDbContext.Users
            .Where(ac => ac.IsActive && ac.Email == email && ac.Password == password)
            .OrderByDescending(u => u.Id)
            .ToListAsync();
    }
}