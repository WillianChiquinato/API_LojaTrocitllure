using Api_LojaTricotllure.Data;
using Api_LojaTricotllure.Interfaces.Repository;
using Api_LojaTricotllure.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_LojaTricotllure.Repository;

public class RetailRepository : IRetailRepository
{
    private readonly AppDbContext _efDbContext;

    public RetailRepository(AppDbContext efDbContext)
    {
        _efDbContext = efDbContext;
    }
    
    public async Task<List<Retail>> GetRetails()
    {
        return await _efDbContext.Retails.ToListAsync();
    }
}