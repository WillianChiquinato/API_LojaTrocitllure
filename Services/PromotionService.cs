using Api_LojaTricotllure.Interfaces;
using Api_LojaTricotllure.Interfaces.Repository;
using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Response;

namespace Api_LojaTricotllure.Services;

public class PromotionService : IPromotionService
{
    private readonly ILogger<PromotionService> _logger;
    private readonly IPromotionRepository _promotionRepository;
    
    public PromotionService(ILogger<PromotionService> logger, IPromotionRepository promotionRepository)
    {
        _logger = logger;
        _promotionRepository = promotionRepository;
    }

    public async Task<CustomResponse<Promotion>> GetPromotions()
    {
        try
        {
            var promotion = await _promotionRepository.GetPromotions();

            return CustomResponse<Promotion>.SuccessTrade(promotion);
        }
        catch (Exception ex)
        {
            return CustomResponse<Promotion>.Fail("Erro ao buscar promoção", ex.Message);
        }
    }
}