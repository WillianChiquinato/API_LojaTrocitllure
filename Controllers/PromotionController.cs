using Api_LojaTricotllure.Data;
using Api_LojaTricotllure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PromotionController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IPromotionService _promotionService;

    public PromotionController(AppDbContext context, IPromotionService promotionService)
    {
        _context = context;
        _promotionService = promotionService;
    }

    [HttpGet]
    [Route("GetPromotions")]
    public async Task<IActionResult> GetPromotions()
    {
        var promotions = await _promotionService.GetPromotions();
        
        return promotions.Result != null ? Ok(promotions) : NotFound();
    }
}