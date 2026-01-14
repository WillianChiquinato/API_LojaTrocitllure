using Api_LojaTricotllure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductConsolidatedsSkuController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductConsolidatedsSkuController(AppDbContext context)
    {
        _context = context;
    }
}