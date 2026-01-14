using Api_LojaTricotllure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductConsolidatedsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductConsolidatedsController(AppDbContext context)
    {
        _context = context;
    }
}