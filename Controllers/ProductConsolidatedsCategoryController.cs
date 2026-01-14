using Api_LojaTricotllure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductConsolidatedsCategoryController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductConsolidatedsCategoryController(AppDbContext context)
    {
        _context = context;
    }
}