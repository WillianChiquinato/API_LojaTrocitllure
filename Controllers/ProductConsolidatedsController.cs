using Api_LojaTricotllure.Data;
using Api_LojaTricotllure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductConsolidatedsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IProductConsolidatedsService _productConsolidateds;

    public ProductConsolidatedsController(AppDbContext context, IProductConsolidatedsService productConsolidateds)
    {
        _context = context;
        _productConsolidateds = productConsolidateds;
    }

    [HttpGet]
    [Route("GetProductsConsolidateds")]
    public async Task<IActionResult> GetProductsConsolidateds([FromQuery] int page, [FromQuery] int pageSize)
    {
        var products = await _productConsolidateds.GetProductsConsolidateds(page, pageSize);
        
        return products.Result != null ? Ok(products) : NotFound();
    }

    [HttpGet]
    [Route("VerifyStock")]
    public async Task<IActionResult> VerifyStock([FromQuery] int productId, [FromQuery] string size, [FromQuery] string color, [FromQuery] int? quantity)
    {
        var stockVerification = await _productConsolidateds.VerifyStock(productId, size, color, quantity);
        
        return stockVerification.Result != null ? Ok(stockVerification) : NotFound();
    }
}