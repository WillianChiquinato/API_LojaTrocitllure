using Api_LojaTricotllure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductConsolidatedsImageController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductConsolidatedsImageController(AppDbContext context)
    {
        _context = context;
    }
}