using Api_LojaTricotllure.Data;
using Api_LojaTricotllure.Interfaces.Repository;
using Api_LojaTricotllure.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_LojaTricotllure.Repository;

public class PromotionRepository : IPromotionRepository
{
    private readonly AppDbContext _efDbContext;

    public PromotionRepository(AppDbContext efDbContext)
    {
        _efDbContext = efDbContext;
    }

    public async Task<Promotion?> GetPromotions()
    {
        var today = DateTime.Today;
        var tomorrow = today.AddDays(1);

        return await _efDbContext.Promotions
            .Where(p =>
                p.StartsAt < tomorrow &&
                p.EndsAt >= today
            )
            .OrderByDescending(p => p.Id)
            .FirstOrDefaultAsync();
    }
}