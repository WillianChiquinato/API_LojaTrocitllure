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

    public ProductConsolidatedsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("GetProductsConsolidateds")]
    public async Task<IActionResult> GetProductsConsolidateds([FromQuery] int page, [FromQuery] int pageSize)
    {
        var products = await _productConsolidateds.GetProductsConsolidateds(page, pageSize);
        
        return products.Result != null ? Ok(products) : NotFound();
    }
}