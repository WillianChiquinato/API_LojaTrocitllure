using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Response;

namespace Api_LojaTricotllure.Interfaces;

public interface IPromotionService
{
    public Task<CustomResponse<Promotion>> GetPromotions();
}