using Api_LojaTricotllure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RetailController : ControllerBase
{
    private readonly AppDbContext _context;

    public RetailController(AppDbContext context)
    {
        _context = context;
    }
}