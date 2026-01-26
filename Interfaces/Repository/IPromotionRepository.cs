using Api_LojaTricotllure.Models;

namespace Api_LojaTricotllure.Interfaces.Repository;

public interface IPromotionRepository
{
    public Task<Promotion> GetPromotions();
}